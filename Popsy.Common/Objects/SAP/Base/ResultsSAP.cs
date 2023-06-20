namespace Popsy.Objects
{
    public record ResultsSAP<T>
        where T : class
    {
        public IEnumerable<T> results { get; set; } = new HashSet<T>();
    }
}