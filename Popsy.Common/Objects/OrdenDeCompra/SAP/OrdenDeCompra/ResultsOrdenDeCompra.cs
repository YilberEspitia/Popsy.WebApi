namespace Popsy.Objects
{
    public record ResultsOrdenDeCompra
    {
        public IEnumerable<ResultOrdenDeCompra> results { get; set; } = new HashSet<ResultOrdenDeCompra>();
    }
}