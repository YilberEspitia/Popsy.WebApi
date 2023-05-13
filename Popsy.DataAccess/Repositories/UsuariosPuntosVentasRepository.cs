using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class UsuariosPuntosVentasRepository : IUsuariosPuntosVentasRepository
    {
        private readonly PopsyDbContext _context;

        public UsuariosPuntosVentasRepository(PopsyDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TblUsuarioPuntoVentaEntity>> GetUsuariosPuntosVentas(Guid usuario_id)
        {
            IEnumerable<TblUsuarioPuntoVentaEntity> vista = await _context.UsuariosPuntoDeVenta.Where(l => l.usuario_id == usuario_id).ToListAsync();
            return vista;
        }
    }
}