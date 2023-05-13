namespace Popsy.Entities
{
    public class TblCreableEntity
    {
        public DateTime fecha_creacion { get; protected set; }
        public DateTime fecha_modificacion { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        protected TblCreableEntity()
        {
            this.fecha_creacion = DateTime.UtcNow;
        }
    }
}