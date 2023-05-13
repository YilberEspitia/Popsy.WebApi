using Popsy.Entities;
using Popsy.Helpers;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Integrations
{
    public class Integraciones : IIntegraciones
    {
        private IProductosPedidosRepository _repoProductosPedido;
        private IDeterminarComprasTrasladosRepository _repoDeterminarComprasTraslados;
        private IVistaPedidosPuntoVentaRepository _repoPedidosPuntoVenta;
        private XMLEnvioPedidoSAP _XMLPedido;

        public Integraciones(IProductosPedidosRepository repoProductosPedido
        , IDeterminarComprasTrasladosRepository repoDeterminarComprasTraslados
        , IVistaPedidosPuntoVentaRepository repoPedidosPuntoVenta
        , XMLEnvioPedidoSAP XMLPedido)
        {
            _repoProductosPedido = repoProductosPedido;
            _repoDeterminarComprasTraslados = repoDeterminarComprasTraslados;
            _repoPedidosPuntoVenta = repoPedidosPuntoVenta;
            _XMLPedido = XMLPedido;
        }

        public async Task<RespuestaServicioEntity> GetRespuestaPedidoSAPIntegracion(Guid pedido_id)
        {
            RespuestaServicioEntity respuesta = new RespuestaServicioEntity();
            List<TblProductoPedidoEntity> productosPedido = await _repoProductosPedido.GetProductoPedidoId(pedido_id);
            List<TblDeterminarCompraTrasladoEntity> determinarComprasTraslados = await _repoDeterminarComprasTraslados.GetDeterminarComprasTraslados();

            List<TblProductoPedidoEntity> productosOrdenTraslado = new List<TblProductoPedidoEntity>();
            List<TblProductoPedidoEntity> productosOrdenCompra = new List<TblProductoPedidoEntity>();

            foreach (TblProductoPedidoEntity productosPedidoFila in productosPedido)
            {
                TblDeterminarCompraTrasladoEntity validarDeterminar = determinarComprasTraslados.FirstOrDefault(l => l.producto_id == productosPedidoFila.producto_id);
                if (validarDeterminar == null)
                {
                    productosOrdenTraslado.Add(productosPedidoFila);
                }
                else
                {
                    if (validarDeterminar.requiere_pedido_compra == 1)
                    {
                        productosOrdenCompra.Add(productosPedidoFila);
                    }
                    else
                    {
                        productosOrdenTraslado.Add(productosPedidoFila);
                    }
                }
            }

            List<List<TblProductoPedidoEntity>> proveedoresProductosPedidoOC = new List<List<TblProductoPedidoEntity>>();
            //Ludwig: Recorrer listas y separar por proveedores
            //ZTRA Traslado
            //NB Orden Compra
            foreach (List<TblProductoPedidoEntity> proveedorSeparadoOC in proveedoresProductosPedidoOC)
            {
                string TipoDocumento = "NB";
                ZMF_PUNTO_VENTA infoXML = await _XMLPedido.CargarInfoXML(proveedorSeparadoOC, TipoDocumento, pedido_id);
                string path = _XMLPedido.EnviarXMLPedido(infoXML);
                //Ludwig Enviar correo electronico
            }
            respuesta.Respuesta = "Gracias";
            return respuesta;
        }
    }
}