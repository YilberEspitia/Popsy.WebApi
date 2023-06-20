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

        async Task<TblProductoEntity?> IProductosRepository.GetProductosByCodigo(string codigo)
        {
            TblProductoEntity? vista = await _context.Productos.FirstOrDefaultAsync(l => l.codigo == codigo);
            return vista;
        }

        public async Task<TblProductoEntity?> GetProductosById(Guid producto_id)
        {
            TblProductoEntity? vista = await _context.Productos.FirstOrDefaultAsync(l => l.producto_id == producto_id);
            return vista;
        }
    }
}