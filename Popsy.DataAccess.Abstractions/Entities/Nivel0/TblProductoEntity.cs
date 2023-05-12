using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("productos")]
    public class TblProductoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid producto_id { get; set; }
        public string nombre { get; set; } = default!;
        public string codigo { get; set; } = default!;
        public string presentacion { get; set; } = default!;
        public string minima_unidad { get; set; } = default!;
        public int? habilitado_inventario { get; set; }
        public int? habilitado_pedido { get; set; }
        public string categoria_producto { get; set; } = default!;
        public string? contador { get; set; }
        public string? denominador { get; set; }
        public string Categoria_Producto1 { get; set; } = default!;
        public string Categoria_Producto2 { get; set; } = default!;
        public string? categoria_producto3 { get; set; }
        public string? categoria_producto4 { get; set; }
        #endregion

        #region Relaciones
        public virtual ISet<TblDeterminarCompraTrasladoEntity> determinar_compra_traslados { get; protected set; } = new HashSet<TblDeterminarCompraTrasladoEntity>();
        public virtual ISet<TblProductoFactorConversionEntity> factores_de_conversion { get; protected set; } = new HashSet<TblProductoFactorConversionEntity>();
        public virtual ISet<TblProductoPedidoEntity> pedidos { get; protected set; } = new HashSet<TblProductoPedidoEntity>();
        public virtual ISet<TblProductoPuntoVentaEntity> puntos_de_venta { get; protected set; } = new HashSet<TblProductoPuntoVentaEntity>();
        public virtual ISet<TblDetalleOrdenDeCompraEntity> detalles_ordenes_de_compra { get; protected set; } = new HashSet<TblDetalleOrdenDeCompraEntity>();
        #endregion
    }
}