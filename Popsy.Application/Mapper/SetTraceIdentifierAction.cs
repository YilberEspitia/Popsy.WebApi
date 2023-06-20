using System.Diagnostics.CodeAnalysis;

using AutoMapper;

using Popsy.Entities;
using Popsy.Objects;

namespace Popsy
{
    [ExcludeFromCodeCoverage]
    internal class SetTraceIdentifierAction :
        IMappingAction<TblPuntoVentaEntity, ReadPuntoVenta>,
        IMappingAction<TblProductoEntity, ReadProductosEntity>,
        IMappingAction<TblDetalleOrdenDeCompraEntity, DetalleOrdenDeCompraRead>
    {
        public void Process(TblPuntoVentaEntity source, ReadPuntoVenta destination, ResolutionContext context)
        {
            destination.nombre_punto_venta = source.nombre;
            destination.codigo_punto_venta = source.codigo;
        }

        public void Process(TblProductoEntity source, ReadProductosEntity destination, ResolutionContext context)
        {
            destination.producto_nombre = source.nombre;
        }

        public void Process(TblDetalleOrdenDeCompraEntity source, DetalleOrdenDeCompraRead destination, ResolutionContext context)
        {
            if (source.producto is not null)
                destination.codigo_producto = source.producto.codigo;
        }
    }
}
