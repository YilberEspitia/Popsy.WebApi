using Microsoft.AspNetCore.Mvc;

using Popsy.Entities;
using Popsy.Interfaces;
using Popsy.Objects;

namespace WebApiIntegracion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly IVistaCategoriasProductosRepository _repoVistaCategoriasProductos;
        private readonly IVistaProductosConStockRepository _repoVistaProductosConSotck;

        private readonly IReadInventarioBaseRepository _repoReadInventarioBase;
        private readonly ICreateInventarioBaseBusiness _repoCreateInventarioBase;
        private readonly IVistaMonitorInventarioRepository _repoReadInventarioMonitor;
        private readonly IVistaResumenInventarioRepository _repoResumenInventario;
        private readonly IUsuariosPuntosVentasRepository _repoUsuariosPuntosVentas;
        private readonly IVistaPuntosVentaBodegasRepository _repoPuntosVentaBodegas;
        private readonly IPuntosVentasRepository _repoPuntosVenta;
        private readonly ITipoInventariosRepository _repoTipoInventarios;
        public InventarioController(IVistaCategoriasProductosRepository repoVistaCategoriasProductos, IVistaProductosConStockRepository repoVistaProductosConSotck
        , IReadInventarioBaseRepository repoReadInventarioBase
        , ICreateInventarioBaseBusiness repoCreateInventarioBase
        , IVistaMonitorInventarioRepository repoReadInventarioMonitor
        , IVistaResumenInventarioRepository repoResumenInventario
        , IUsuariosPuntosVentasRepository repoUsuariosPuntosVentas
        , ITipoInventariosRepository repoTipoInventarios
        , IVistaPuntosVentaBodegasRepository repoPuntosVentaBodegas
        , IPuntosVentasRepository repoPuntosVenta)
        {
            _repoVistaCategoriasProductos = repoVistaCategoriasProductos;
            _repoVistaProductosConSotck = repoVistaProductosConSotck;
            _repoReadInventarioBase = repoReadInventarioBase;
            _repoCreateInventarioBase = repoCreateInventarioBase;
            _repoReadInventarioMonitor = repoReadInventarioMonitor;
            _repoResumenInventario = repoResumenInventario;
            _repoUsuariosPuntosVentas = repoUsuariosPuntosVentas;
            _repoTipoInventarios = repoTipoInventarios;
            _repoPuntosVentaBodegas = repoPuntosVentaBodegas;
            _repoPuntosVenta = repoPuntosVenta;
        }

        /// <summary>
        /// Obtiene el listado de categorias y subcategorias - no requiere parametros
        /// </summary>
        /// <remarks>
        /// Retorna el listado de Categorias categoria_id y categoria_nombre. Es el listado de categorias de la parte izquierda de la pantalla. Adicional concatenando los factores de conversion retorna las sub categorias
        /// </remarks>        
        [HttpGet]
        [Route("GetVistaCategoriasProductos")]
        public async Task<IActionResult> GetVistaCategoriasProductos()
        {
            var vista = await _repoVistaCategoriasProductos.GetVistaCategoriasProductos();
            return Ok(vista);
        }

        [HttpGet]
        [Route("GetVistaProductosConStock")]
        public async Task<IActionResult> GetVistaProductosConStock()
        {
            var vista = await _repoVistaProductosConSotck.GetVistaProductosConStock();
            return Ok(vista);
        }

        /// <summary>
        /// Obtiene el listado de productos segun categoria seleccionada y usuario
        /// </summary>
        /// <remarks>
        /// Retorna toda la información de la categoria: factores de conversion, bodegas, presentación y productos. 
        /// Los parametros son: La categoria y el usuario id con el que el sistema revisa que punto de venta es. Se sugieren usuario_id = bc75c0db-e6c8-ed11-8927-34735a9c3f29, categoria_id = CATEGORIA2 y sub_categoria = MililitroUnidadUNLitro para prueba.
        /// Es la pantalla donde el usuario digita cuanto inventario hay 
        /// </remarks>        

        [HttpGet]
        [Route("GetInventarioBase")]
        public async Task<IActionResult> GetInventarioBase(Guid punto_venta_id)
        {
            List<ReadInventarioBaseEntity> vista = await _repoReadInventarioBase.GetInventarioBase(punto_venta_id);
            return Ok(vista);
        }

        /// <summary>
        /// Obtiene el listado de inventarios filtrando por el punto de venta del usuario seleccionado
        /// </summary>
        /// <remarks>
        /// Retorna toda la información del monitor de inventarios. Se sugieren usuario_id = bc75c0db-e6c8-ed11-8927-34735a9c3f29 
        /// Es el monitor de inventarios
        /// </remarks>
        [HttpGet]
        [Route("GetInventarioMonitor")]
        public async Task<IActionResult> GetInventarioMonitor(Guid usuario)
        {
            IEnumerable<TblUsuarioPuntoVentaEntity> puntoVentaList = await _repoUsuariosPuntosVentas.GetUsuariosPuntosVentas(usuario);
            TblUsuarioPuntoVentaEntity puntoVenta = new TblUsuarioPuntoVentaEntity();
            if (puntoVentaList.Count() > 0)
            {
                puntoVenta = puntoVentaList.FirstOrDefault();
            }
            IEnumerable<VistaMonitorInventarioEntity> vista = await _repoReadInventarioMonitor.GetInventarioMonitor(puntoVenta.punto_venta_id);
            return Ok(vista);
        }
        /// <summary>
        /// Obtiene el listado de productos filtrado por el inventario_id seleccionado
        /// </summary>
        /// <remarks>
        /// Retorna toda la información con el detalle del inventario 
        /// Es el detalle del inventario seleccionado
        /// </remarks>

        [HttpGet]
        [Route("GetVistaResumenInventario")]
        public async Task<IActionResult> GetVistaResumenInventario()
        {
            IEnumerable<VistaResumenInventarioEntity> vista = await _repoResumenInventario.GetVistaResumenInventario();
            return Ok(vista);
        }

        [HttpGet]
        [Route("GetVistaResumenInventarioById")]
        public async Task<IActionResult> GetVistaResumenInventarioById(Guid inventarios_id)
        {
            IEnumerable<VistaResumenInventarioEntity> vista = await _repoResumenInventario.GetVistaResumenInventarioById(inventarios_id);
            return Ok(vista);
        }

        /// <summary>
        /// Obtiene el punto de venta id, la fecha del ultimo inventario y el listado de los tipos de inventario
        /// </summary>
        /// <remarks>
        /// Retorna toda la información del encabezado que se requiere ara dar inicio al inventario. Se sugieren usuario_id = bc75c0db-e6c8-ed11-8927-34735a9c3f29 
        /// Es el encabezado del inventario 
        /// </remarks>

        [HttpGet]
        [Route("GetEncabezadoInventario")]
        public async Task<IActionResult> GetEncabezadoInventario(Guid usuario)
        {
            IEnumerable<TblTipoInventarioEntity> lista = await _repoTipoInventarios.GetTipoInventario();
            IEnumerable<TblUsuarioPuntoVentaEntity> puntoVentaList = await _repoUsuariosPuntosVentas.GetUsuariosPuntosVentas(usuario);
            List<ReadPuntoVenta> puntoVentaInfo = new List<ReadPuntoVenta>();
            foreach (TblUsuarioPuntoVentaEntity puntoVenta in puntoVentaList)
            {
                IEnumerable<VistaPuntosVentaBodegasEntity> listaBodegas = await _repoPuntosVentaBodegas.GetVistaPuntosVentaBodegasByPuntoVenta(puntoVenta.punto_venta_id);
                IEnumerable<VistaMonitorInventarioEntity> inventarioList = await _repoReadInventarioMonitor.GetInventarioMonitor(puntoVenta.punto_venta_id);
                VistaMonitorInventarioEntity ultimoInventario = inventarioList.OrderByDescending(l => l.fecha_toma_fisica).FirstOrDefault();
                DateTime? fecha = null;
                if (ultimoInventario != null)
                    fecha = ultimoInventario.fecha_toma_fisica;
                ReadPuntoVenta puntoVentaFila = new ReadPuntoVenta();
                puntoVentaFila.bodegas = listaBodegas.Select(t => new VistaPuntosVentaBodegasObject()
                {
                    bodegas_punto_venta_id = t.bodegas_punto_venta_id,
                    bodega_id = t.bodega_id,
                    nombre_bodega = t.nombre_bodega
                });
                if (listaBodegas.Any())
                {
                    puntoVentaFila.nombre_punto_venta = listaBodegas.Select(t => t.nombre_punto_venta).FirstOrDefault()!;
                    puntoVentaFila.codigo_punto_venta = listaBodegas.Select(t => t.codigo_punto_venta).FirstOrDefault()!;
                    puntoVentaFila.punto_venta_id = listaBodegas.Select(t => t.punto_venta_id).FirstOrDefault()!;
                }
                puntoVentaFila.fecha_ultimo_inventario = fecha;
                puntoVentaInfo.Add(puntoVentaFila);
            }

            ReadEncabezadoInventario encabezado = new ReadEncabezadoInventario();
            encabezado.usuario_id = usuario;
            encabezado.puntos_venta = puntoVentaInfo;
            encabezado.tipo_inventario = lista.Select(t => new TipoInventarioEntity()
            {
                tipo_inventario_id = t.tipo_inventario_id,
                nombre_tipo_inventario = t.nombre_tipo_inventario,
                abreviatura_inventario = t.abreviatura_inventario
            });
            return Ok(encabezado);
        }

        /// <summary>
        /// Obtiene los puntos de venta basado en el Usuario Id junto con el detalle de las bodegas
        /// </summary>
        /// <remarks>
        /// Retorna toda la información de los puntos de ventas del usuario seleccionado con el detalle de las bodegas usuario_id = bc75c0db-e6c8-ed11-8927-34735a9c3f29 
        /// Es el encabezado del inventario 
        /// </remarks>

        [HttpGet]
        [Route("GetPuntoVentaDetalle")]
        public async Task<IActionResult> GetPuntoVentaDetalle(Guid usuario)
        {
            IEnumerable<TblUsuarioPuntoVentaEntity> puntoVentaList = await _repoUsuariosPuntosVentas.GetUsuariosPuntosVentas(usuario);
            List<ReadPuntoVentaDetalleEntity> puntoVentaInfo = new List<ReadPuntoVentaDetalleEntity>();
            foreach (TblUsuarioPuntoVentaEntity puntoVenta in puntoVentaList)
            {
                IEnumerable<VistaPuntosVentaBodegasEntity> listaBodegas = await _repoPuntosVentaBodegas.GetVistaPuntosVentaBodegasByPuntoVenta(puntoVenta.punto_venta_id);
                ReadPuntoVentaDetalleEntity puntoVentaFila = new ReadPuntoVentaDetalleEntity();
                if (listaBodegas.Count() > 0)
                {
                    puntoVentaFila.punto_venta_nombre = listaBodegas.Select(t => t.nombre_punto_venta).FirstOrDefault()!;
                    puntoVentaFila.punto_venta_id = listaBodegas.Select(t => t.punto_venta_id).FirstOrDefault();
                    puntoVentaFila.codigo_punto_venta = listaBodegas.Select(t => t.codigo_punto_venta).FirstOrDefault()!;
                }
                else
                {
                    TblPuntoVentaEntity puntos = await _repoPuntosVenta.GetPuntoVentasId(puntoVenta.punto_venta_id);
                    puntoVentaFila.punto_venta_nombre = puntos.nombre;
                    puntoVentaFila.punto_venta_id = puntos.punto_venta_id;
                }
                puntoVentaFila.bodegas = listaBodegas.Select(t => new VistaPuntosVentaBodegasObject()
                {
                    bodegas_punto_venta_id = t.bodegas_punto_venta_id,
                    bodega_id = t.bodega_id,
                    nombre_bodega = t.nombre_bodega
                });
                puntoVentaInfo.Add(puntoVentaFila);
            }
            return Ok(puntoVentaInfo);
        }


        /// <summary>
        /// Hace todos los calculos para enviar a SAP
        /// </summary>
        /// <remarks>
        /// Retorna toda la información de SAP pedido = bc75c0db-e6c8-ed11-8927-34735a9c3f29 
        /// Es el encabezado del inventario 
        /// </remarks>
        [HttpGet]
        [Route("GetRespuestaPedidoSAP")]
        public async Task<IActionResult> GetRespuestaPedidoSAP(Guid pedido_id)
        {
            RespuestaServicioEntity respuesta = new RespuestaServicioEntity();
            respuesta.Respuesta = "Gracias haz enviado el pedido " + pedido_id.ToString();
            return Ok(respuesta);
        }

        /// <summary>
        /// Guarda el inventario con su respectivo detalle
        /// </summary>
        /// <remarks>
        /// Se debe enviar el usuario_id, tipo_inventarios_id y la fecha_registro. Adicional un listado con los productos producto_punto_venta_id, bodega_id, minima_unidad y cantidad
        /// Corresponde al guardado del inventario, envía correo y crea un consecutivo de inventario.
        /// </remarks>


        [HttpPost]
        [Route("CreateInventarioBase")]
        public async Task<IActionResult> CreateInventarioBase(CreateInventarioBaseEntity inventario_base)
        {
            Guid punto_venta = inventario_base.usuario_id;
            RespuestaServicioEntity vista = await _repoCreateInventarioBase.CreateInventarioBase(inventario_base);
            return Ok(vista);
        }

        [HttpPost]
        [Route("UpdateInventarioBase")]
        public async Task<IActionResult> UpdateInventarioBase(UpdateInventarioBaseEntity inventario_base)
        {
            UpdateInventarioBaseEntity vista = await _repoCreateInventarioBase.UpdateInventarioBase(inventario_base);
            return Ok(vista);
        }

    }
}