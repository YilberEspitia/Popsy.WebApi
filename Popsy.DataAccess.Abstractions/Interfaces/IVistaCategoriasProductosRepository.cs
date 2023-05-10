using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IVistaCategoriasProductosRepository
    {
        Task<IEnumerable<VistaCategoriasProductosEntity>> GetVistaCategoriasProductos();
    }
}