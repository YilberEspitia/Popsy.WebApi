using System.Xml.Serialization;

namespace Popsy.Objects
{
    public class item
    {
        public string? PREQ_ITEM { get; set; }
        public string? DOC_TYPE { get; set; }
        public string? PUR_GROUP { get; set; }
        [XmlElement("PREQ_DATE", IsNullable = true)]

        public DateTime? PREQ_DATE { get; set; }
        public string? MATERIAL { get; set; }
        public string? ORDEN_COMPRA { get; set; }
        public string? PLANT { get; set; }
        public string? STORE_LOC { get; set; }
        public string? DELIV_DATE { get; set; }
        public string? QUANTITY { get; set; }
        public string? UNIT { get; set; }
        public string? C_AMT_BAPI { get; set; }
        public string? PURCH_ORG { get; set; }
        public string? MAT_GRP { get; set; }
        public string PREQ_NAME { get; set; }
        public string? SUPPL_PLNT { get; set; }
        public string? ALM_EMISOR { get; set; }
    }
}