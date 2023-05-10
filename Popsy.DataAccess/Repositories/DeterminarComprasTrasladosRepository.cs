using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;


namespace Popsy.Repositories
{
    public class DeterminarComprasTrasladosRepository : IDeterminarComprasTrasladosRepository
    {
        private readonly PopsyDbContext _context;

        public DeterminarComprasTrasladosRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<List<TblDeterminarComprasTrasladosEntity>> IDeterminarComprasTrasladosRepository.GetDeterminarComprasTraslados()
        {
            List<TblDeterminarComprasTrasladosEntity> vista = await _context.TblDeterminarComprasTraslados.ToListAsync();
            return vista;
        }
    }
}