namespace Popsy.Entities
{
    public class TblCreatableEntity
    {
        public DateTime Fecha_de_creacion { get; protected set; }
        public DateTime Fecha_de_modificacion { get; set; }
        /// <summary>
        /// Constructor.
        /// </summary>
        protected TblCreatableEntity()
        {
            this.Fecha_de_creacion = DateTime.UtcNow;
        }
    }
}