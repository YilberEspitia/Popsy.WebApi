using Microsoft.EntityFrameworkCore;

using Popsy.Common;
using Popsy.Entities;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly PopsyDbContext _context;

        public UsuariosRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<IEnumerable<TblUsuarioPuntoVentaEntity>> IUsuariosRepository.GetUsuariosPuntosVentas(Guid usuario_id, bool activos)
            => activos ?
            await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id == usuario_id && !l.fecha_eliminacion.HasValue).ToListAsync() :
            await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id == usuario_id).ToListAsync();
        async Task<IEnumerable<Guid>> IUsuariosRepository.GetUsuariosPuntosVentas2(Guid usuario_id, bool activos)
            => activos ?
            await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id == usuario_id && !l.fecha_eliminacion.HasValue).Select(x => x.punto_venta_id).ToListAsync() :
            await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id == usuario_id).Select(x => x.punto_venta_id).ToListAsync();

        async Task<IEnumerable<PuntoDeVentaInfoRead>> IUsuariosRepository.GetPuntosDeVentaInfoAsync(Guid usuario_id)
            => await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id.Equals(usuario_id) && !l.fecha_eliminacion.HasValue)
                .Include(x => x.punto_de_venta).ThenInclude(x => x.inventarios2).ThenInclude(x => x.tipo_inventario)
                .Include(x => x.punto_de_venta).ThenInclude(x => x.bodega_puntos_de_venta).ThenInclude(x => x.bodega)
                .Select(x => new PuntoDeVentaInfoRead
                {
                    Punto_venta_id = x.punto_venta_id,
                    Nombre_punto_venta = x.punto_de_venta.nombre,
                    Codigo_punto_venta = x.punto_de_venta.codigo,
                    Fecha_ultimo_inventario = x.punto_de_venta.inventarios2.OrderByDescending(x => x.fecha_creacion).Select(x => x.fecha_creacion).FirstOrDefault(),
                    Nombre_tipo_inventario = x.punto_de_venta.inventarios2.OrderByDescending(x => x.fecha_creacion).Select(x => x.tipo_inventario.nombre_tipo_inventario).FirstOrDefault(),
                    Bodegas = x.punto_de_venta.bodega_puntos_de_venta.Select(b => new BodegaInfoRead
                    {
                        Bodegas_punto_venta_id = b.bodega_punto_venta_id,
                        Bodega_id = b.bodegas_id,
                        Nombre_bodega = b.bodega.nombre_bodega
                    }).ToHashSet()
                }).ToListAsync();

        async Task<IEnumerable<PuntoDeVentaInfoRead>> IUsuariosRepository.GetAllPuntosDeVentaInfoAsync()
            => await _context.PuntosDeVenta
                .Include(x => x.inventarios2).ThenInclude(x => x.tipo_inventario)
                .Include(x => x.bodega_puntos_de_venta).ThenInclude(x => x.bodega)
                .Select(x => new PuntoDeVentaInfoRead
                {
                    Punto_venta_id = x.punto_venta_id,
                    Nombre_punto_venta = x.nombre,
                    Codigo_punto_venta = x.codigo,
                    Fecha_ultimo_inventario = x.inventarios2.OrderByDescending(x => x.fecha_creacion).Select(x => x.fecha_creacion).FirstOrDefault(),
                    Nombre_tipo_inventario = x.inventarios2.OrderByDescending(x => x.fecha_creacion).Select(x => x.tipo_inventario.nombre_tipo_inventario).FirstOrDefault(),
                    Bodegas = x.bodega_puntos_de_venta.Select(b => new BodegaInfoRead
                    {
                        Bodegas_punto_venta_id = b.bodega_punto_venta_id,
                        Bodega_id = b.bodegas_id,
                        Nombre_bodega = b.bodega.nombre_bodega
                    }).ToHashSet()
                }).ToListAsync();

        async Task<String?> IUsuariosRepository.GetNombreDeUsuarioAsync(Guid usuario_id)
            => await _context.Usuarios.Where(x => x.usuario_id.Equals(usuario_id) && !x.fecha_eliminacion.HasValue).Select(x => $"{x.nombres} {x.apellidos}").FirstOrDefaultAsync();

        async Task<IEnumerable<TblTipoInventarioEntity>> IUsuariosRepository.GetTipoInventariosAsync()
             => await _context.TiposDeInventario.ToListAsync();

        async Task<Boolean> IUsuariosRepository.EsSuperUsuario(Guid usuario_id)
            => await _context.RolesDeUsuarios.Include(x => x.rol).Where(x => x.usuario_id.Equals(usuario_id) && x.rol.nombre.ToUpper().Equals(PopsyConstants.RolSU.ToUpper())).AnyAsync();
    }
}