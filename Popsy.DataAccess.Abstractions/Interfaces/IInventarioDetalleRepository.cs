namespace Popsy.Interfaces
{
    public interface IInventarioDetalleRepository
    {
        void Add<T>(T entity) where T : class;
    }
}