using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("usuarios")]
    public class TblUsuarioEntity
    {
        #region Atributos
        [Key]
        public Guid usuario_id { get; set; }
        public string nombres { get; set; } = default!;
        public string apellidos { get; set; } = default!;
        [MaxLength(20)]
        public string cedula { get; set; } = default!;
        public string correo { get; set; } = default!;
        public int estado { get; set; }
        public string password { get; set; } = default!;
        public DateTime? fecha_eliminacion { get; set; }
        #endregion

        #region Relaciones
        public virtual ISet<TblInventarioEntity> inventarios { get; protected set; } = new HashSet<TblInventarioEntity>();
        public virtual ISet<TblInventario2Entity> inventarios2 { get; protected set; } = new HashSet<TblInventario2Entity>();
        public virtual ISet<TblPedidoEntity> pedidos { get; protected set; } = new HashSet<TblPedidoEntity>();
        public virtual ISet<TblUsuarioPuntoVentaEntity> puntos_de_venta { get; protected set; } = new HashSet<TblUsuarioPuntoVentaEntity>();
        public virtual ISet<TblHistorialUsuarioEntity> historial { get; protected set; } = new HashSet<TblHistorialUsuarioEntity>();
        public virtual ISet<TblUsuarioRolEntity> roles { get; protected set; } = new HashSet<TblUsuarioRolEntity>();
        #endregion
    }
}
