using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("puntos_ventas")]
    public class TblPuntoVentaEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid punto_venta_id { get; set; }
        public string codigo { get; set; } = default!;
        public string nombre { get; set; } = default!;
        public string direccion { get; set; } = default!;
        [MaxLength(25)]
        public string CENTRO_CONOS { get; set; } = default!;
        [MaxLength(25)]
        public string ALMACEN_CONOS { get; set; } = default!;
        [MaxLength(25)]
        public string DOC_CONOS { get; set; } = default!;
        [MaxLength(25)]
        public string CENTRO_CS { get; set; } = default!;
        [MaxLength(25)]
        public string ALMACEN_CS { get; set; } = default!;
        [MaxLength(25)]
        public string DOC_CS { get; set; } = default!;
        [MaxLength(25)]
        public string CENTRO_CG { get; set; } = default!;
        [MaxLength(25)]
        public string ALMACEN_CG { get; set; } = default!;
        [MaxLength(25)]
        public string DOC_CG { get; set; } = default!;
        [MaxLength(25)]
        public string CENTRO_CGR { get; set; } = default!;
        [MaxLength(25)]
        public string ALMACEN_CGR { get; set; } = default!;
        [MaxLength(25)]
        public string DOC_CGR { get; set; } = default!;
        [MaxLength(25)]
        public string CENTRO_CSR { get; set; } = default!;
        public string ALMACEN_CSR { get; set; } = default!;
        [MaxLength(25)]
        public string DOC_CSR { get; set; } = default!;
        [MaxLength(25)]
        public string CENTRO_UT { get; set; } = default!;
        [MaxLength(25)]
        public string ALMACEN_UT { get; set; } = default!;
        [MaxLength(25)]
        public string DOC_UT { get; set; } = default!;
        #endregion
        #region Relaciones
        public Guid distrito_id { get; set; }
        [ForeignKey("distrito_id")]
        public virtual TblDistritoEntity distrito { get; protected set; } = default!;
        public virtual ISet<TblBodegaPuntoVentaEntity> bodega_puntos_de_venta { get; protected set; } = new HashSet<TblBodegaPuntoVentaEntity>();
        public virtual ISet<TblDeterminarCompraTrasladoEntity> determinar_compra_traslados { get; protected set; } = new HashSet<TblDeterminarCompraTrasladoEntity>();
        public virtual ISet<TblTipoPedidoPorAlmacenEntity> tipos_de_pedido_por_almacen { get; protected set; } = new HashSet<TblTipoPedidoPorAlmacenEntity>();
        public virtual ISet<TblPedidoEntity> pedidos { get; protected set; } = new HashSet<TblPedidoEntity>();
        public virtual ISet<TblProductoPuntoVentaEntity> productos { get; protected set; } = new HashSet<TblProductoPuntoVentaEntity>();
        public virtual ISet<TblUsuarioPuntoVentaEntity> usuarios { get; protected set; } = new HashSet<TblUsuarioPuntoVentaEntity>();
        public virtual ISet<TblInventarioEntity> inventarios { get; protected set; } = new HashSet<TblInventarioEntity>();
        public virtual ISet<TblInventario2Entity> inventarios2 { get; protected set; } = new HashSet<TblInventario2Entity>();
        public virtual ISet<TblOrdenDeCompraEntity> ordenes_de_compra { get; protected set; } = new HashSet<TblOrdenDeCompraEntity>();
        public virtual ISet<TblStockAFechaEntity> stocks_a_fecha { get; protected set; } = new HashSet<TblStockAFechaEntity>();
        #endregion
    }
}
