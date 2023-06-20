namespace Popsy.Objects
{
    public record ItemSoItem
    {
        public IEnumerable<ItemOrdenDeCompraSAP> item { get; set; } = new HashSet<ItemOrdenDeCompraSAP>();
    }
}
