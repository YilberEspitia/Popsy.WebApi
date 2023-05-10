namespace Popsy.Objects
{
    [Serializable]
    public class ZMF_PUNTO_VENTA
    {
        public string? ORDEN_COMPRA { get; set; }
        public string? SOLPED { get; set; }
        public string? SOLPED_DELETE { get; set; }
        public string? TIPODOC_PT { get; set; }
        public List<item> T_ITEMS { get; set; }
        public List<T_RETURN> T_RETURN { get; set; }

    }
}