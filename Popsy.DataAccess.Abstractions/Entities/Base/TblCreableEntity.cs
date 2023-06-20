using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    public class TblCreableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime fecha_creacion { get; protected set; }
        public DateTime fecha_modificacion { get; set; }
    }
}