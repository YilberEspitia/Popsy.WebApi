using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class EmailInfoRepository : IEmailInfoRepository
    {
        private readonly PopsyDbContext _context;

        public EmailInfoRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<string> IEmailInfoRepository.GetNombreBodega(Guid bodega_id)
        {
            string response = bodega_id.ToString();
            if (await _context.Bodegas.Where(x => x.bodega_id.Equals(bodega_id)).FirstOrDefaultAsync() is TblBodegaEntity bodegaDb)
                response = bodegaDb.nombre_bodega;
            return response;
        }

        async Task<string> IEmailInfoRepository.GetNombreProducto(Guid producto_id)
        {
            string response = producto_id.ToString();
            if (await _context.Productos.Where(x => x.producto_id.Equals(producto_id)).FirstOrDefaultAsync() is TblProductoEntity productoDb)
                response = productoDb.nombre;
            return response;
        }

        async Task<string> IEmailInfoRepository.GetNombrePuntoDeVenta(Guid punto_venta_id)
        {
            string response = punto_venta_id.ToString();
            if (await _context.PuntosDeVenta.Where(x => x.punto_venta_id.Equals(punto_venta_id)).FirstOrDefaultAsync() is TblPuntoVentaEntity puntoVentaDb)
                response = puntoVentaDb.nombre;
            return response;
        }

        async Task<string> IEmailInfoRepository.GetNombrePuntoDeVentaPorRecepcion(Guid recepcion_id)
        {
            string response = recepcion_id.ToString();
            if (await _context.RecepcionesDeCompra.Where(x => x.recepcion_compra_id.Equals(recepcion_id))
                .Include(x => x.orden_de_compra).ThenInclude(x => x.punto_de_venta).FirstOrDefaultAsync() is TblRecepcionDeCompraEntity recepcionDb)
                response = recepcionDb.orden_de_compra.punto_de_venta.nombre;
            return response;
        }

        async Task<string> IEmailInfoRepository.GetProveedorRepcionPorRecepcion(Guid recepcion_id)
        {
            string response = recepcion_id.ToString();
            if (await _context.RecepcionesDeCompra.Where(x => x.recepcion_compra_id.Equals(recepcion_id))
                .Include(x => x.orden_de_compra).ThenInclude(x => x.proveedor_recepcion).FirstOrDefaultAsync() is TblRecepcionDeCompraEntity recepcionDb)
                response = recepcionDb.orden_de_compra.proveedor_recepcion.nombre;
            return response;
        }

        async Task<string> IEmailInfoRepository.GetTipoDeInventario(Guid tipo_inventario_id)
        {
            string response = tipo_inventario_id.ToString();
            if (await _context.TiposDeInventario.Where(x => x.tipo_inventario_id.Equals(tipo_inventario_id)).FirstOrDefaultAsync() is TblTipoInventarioEntity tipoDb)
                response = tipoDb.nombre_tipo_inventario;
            return response;
        }

        async Task<string> IEmailInfoRepository.GetUsuarioMail(Guid usuario_id)
        {
            string response = usuario_id.ToString();
            if (await _context.Usuarios.Where(x => x.usuario_id.Equals(usuario_id)).FirstOrDefaultAsync() is TblUsuarioEntity usuarioDb)
                response = usuarioDb.correo;
            return response;
        }
    }
}