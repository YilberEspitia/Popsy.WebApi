﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Popsy.Entities
{
    [Table("pedidos")]
    public class TblPedidoEntity : TblCreableEntity
    {
        #region Atributos
        [Key]
        public Guid pedido_id { get; set; }
        public string? mensajeReciboSap { get; set; }
        public string? FechaMensajeSap { get; set; }
        public string? DocumentoUnoSap { get; set; }
        public string? DocumentoDosSap { get; set; }
        public Guid usuario_id { get; set; }
        #endregion

        #region Relaciones
        public Guid tipo_pedido_id { get; set; }
        [ForeignKey("tipo_pedido_id")]
        public virtual TblTipoPedidoEntity tipo_pedido { get; protected set; } = default!;
        public Guid punto_venta_id { get; set; }
        [ForeignKey("punto_venta_id")]
        public virtual TblPuntoVentaEntity punto_de_venta { get; protected set; } = default!;
        public Guid estado_pedido_id { get; set; }
        [ForeignKey("estado_pedido_id")]
        public virtual TblEstadoPedidoEntity estado_de_pedido { get; protected set; } = default!;
        public virtual ISet<TblTransaccionEntity> transacciones { get; protected set; } = new HashSet<TblTransaccionEntity>();
        public virtual ISet<TblProductoPedidoEntity> pedidos { get; protected set; } = new HashSet<TblProductoPedidoEntity>();
        #endregion

    }
}
