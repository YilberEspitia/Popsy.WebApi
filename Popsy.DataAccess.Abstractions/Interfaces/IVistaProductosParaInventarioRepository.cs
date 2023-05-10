using Popsy.Entities;

namespace Popsy.Interfaces
{
    public interface IVistaProductosParaInventarioRepository
    {
        Task<IEnumerable<VistaProductosParaInventarioEntity>> GetVistaProductosParaInventarioByCategoria(string categoria_id);
        Task<IEnumerable<VistaProductosParaInventarioEntity>> GetVistaProductosParaInventario();
    }
}