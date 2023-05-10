using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class InventarioDetalleRepository : IInventarioDetalleRepository
    {
        private readonly PopsyDbContext _context;

        public InventarioDetalleRepository(PopsyDbContext context)
        {
            _context = context;
        }
        void IInventarioDetalleRepository.Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}