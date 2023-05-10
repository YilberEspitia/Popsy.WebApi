using Popsy.Interfaces;

namespace Popsy.Repositories
{
    public class InventariosRepository : IInventariosRepository
    {
        private readonly PopsyDbContext _context;

        public InventariosRepository(PopsyDbContext context)
        {
            _context = context;
        }
        void IInventariosRepository.Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }
    }
}