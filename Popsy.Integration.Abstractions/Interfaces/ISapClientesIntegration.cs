namespace Popsy.Interfaces
{
    public interface ISapClientesIntegration
    {
        Task<IEnumerable<dynamic>> GetSapClientes();
    }
}