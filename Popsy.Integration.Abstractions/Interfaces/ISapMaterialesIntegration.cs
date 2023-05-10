namespace Popsy.Interfaces
{
    public interface ISapMaterialesIntegration
    {
        Task<IEnumerable<dynamic>> GetSapMateriales();
    }
}