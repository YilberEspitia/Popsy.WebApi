namespace Popsy.Objects
{
    public record ItemOrdenDeCompraSAP
    {
        public string PoNumber { get; set; }
        public string PoItem { get; set; }
        public string MoveType { get; set; }
        public string EntryQnt { get; set; }
        public string EntryUom { get; set; }
        public string MvtInd { get; set; }
    }
}
