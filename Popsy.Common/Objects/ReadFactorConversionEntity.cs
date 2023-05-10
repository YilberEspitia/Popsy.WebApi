using System.ComponentModel.DataAnnotations;

namespace Popsy.Objects
{
    public class ReadFactorConversionEntity
    {
        [Key]
        public string factor_conversion_id { get; set; }
        public string factor_conversion_nombre { get; set; }
        public List<ReadBodegaEntity>? bodegas { get; set; }
    }
}