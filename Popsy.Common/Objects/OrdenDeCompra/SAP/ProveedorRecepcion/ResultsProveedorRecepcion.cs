namespace Popsy.Objects
{
    public record ResultsProveedorRecepcion
    {
        public IEnumerable<ResultProveedorRecepcion> results { get; set; } = new HashSet<ResultProveedorRecepcion>();
    }
}