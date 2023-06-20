﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    public class TblSeguimientoPDVEntity
    {
        #region Atributos
        [Required, MaxLength(3)]
        public String COMPAÑIA { get; set; } = default!;
        [Column(TypeName = "nvarchar(45)")]
        public String? PdV { get; set; } = default!;
        [Column(name: "ULTIMA ACTUALIZACION DEL SISTEMA")]
        public DateTime ULTIMA_ACTUALIZACION { get; set; }
        public Int32 T_EN_COLA { get; set; }
        public Int32 T_HOY { get; set; }
        #endregion
    }
}
