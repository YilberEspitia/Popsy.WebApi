namespace Popsy.Objects
{
    public record ItemRecepcionDeCompraSAP
    {
        public string Consecutivo { get; set; }
        public string GoodsmvtCode { get; set; }
        public string PstngDate { get; set; }
        public string VerGrGiSlip { get; set; }
        public string VerGrGiSlipx { get; set; }

        public ItemSoItem SoItem { get; set; }
    }
}
