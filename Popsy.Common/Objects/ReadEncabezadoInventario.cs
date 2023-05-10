using System.ComponentModel.DataAnnotations;

using Popsy.Entities;

namespace Popsy.Objects
{
    public class ReadEncabezadoInventario
    {
        [Key]
        public Guid usuario_id { get; set; }
        public string usuario_nombre { get; set; }
        public IEnumerable<ReadPuntoVenta> puntos_venta { get; set; }
        public IEnumerable<TblTipoInventarioEntity> tipo_inventario { get; set; }
    }
}