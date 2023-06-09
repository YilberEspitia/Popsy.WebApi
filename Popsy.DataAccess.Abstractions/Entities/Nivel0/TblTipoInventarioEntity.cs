﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("tipoinventario", Schema = "SIPOP")]
    public class TblTipoInventarioEntity
    {
        #region Atributos
        [Key]
        public Guid tipo_inventario_id { get; set; }
        [MaxLength(100)]
        public string nombre_tipo_inventario { get; set; } = default!;
        [MaxLength(50)]
        public string? abreviatura_inventario { get; set; }
        #endregion

        #region Relaciones
        public virtual ISet<TblInventarioEntity> inventarios { get; protected set; } = new HashSet<TblInventarioEntity>();
        public virtual ISet<TblInventario2Entity> inventarios2 { get; protected set; } = new HashSet<TblInventario2Entity>();
        #endregion
    }
}
