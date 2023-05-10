using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class ProductosRepository : IProductosRepository
    {
        private readonly PopsyDbContext _context;

        public ProductosRepository(PopsyDbContext context)
        {
            _context = context;
        }

        async Task<TblProductosEntity> IProductosRepository.GetProductosByCodigo(string codigo)
        {
            TblProductosEntity vista = await _context.TblProductos.FirstOrDefaultAsync(l => l.codigo == codigo);
            return vista;
        }

        public async Task<TblProductosEntity> GetProductosById(Guid producto_id)
        {
            TblProductosEntity vista = await _context.TblProductos.FirstOrDefaultAsync(l => l.producto_id == producto_id);
            return vista;
        }
    }
}