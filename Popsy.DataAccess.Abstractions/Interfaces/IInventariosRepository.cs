namespace Popsy.Interfaces
{
    public interface IInventariosRepository
    {
        void Add<T>(T entity) where T : class;
    }
}