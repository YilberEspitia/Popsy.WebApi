using AutoMapper;

using Popsy.Entities;
using Popsy.Objects;

namespace Popsy
{
    /// <summary>
    /// Mapeo de entidades a objetos o viceversa.
    /// </summary>
    public class ApplicationAppProfile : Profile
    {
        /// <summary>
        /// Constructor.
        /// </summary>
        public ApplicationAppProfile()
        {
            this.MapProveedorRecepcion();
            this.MapOrdenDeCompra();
            this.MapRecepcionDeCompra();
            this.MapProducto();
        }

        public void MapProveedorRecepcion()
        {
            CreateMap<ProveedorRecepcionObject, TblProveedorRecepcionEntity>().ReverseMap();
        }

        public void MapOrdenDeCompra()
        {
            CreateMap<OrdenDeCompraSave, TblOrdenDeCompraEntity>()
                .ForMember(m => m.detalles_ordenes_de_compra, m => m.Ignore());
            CreateMap<DetalleOrdenDeCompraSave, TblDetalleOrdenDeCompraEntity>();
            CreateMap<TblOrdenDeCompraEntity, OrdenDeCompraRead>();
            CreateMap<TblDetalleOrdenDeCompraEntity, DetalleOrdenDeCompraRead>();
            CreateMap<TblPuntoVentaEntity, ReadPuntoVenta>()
                .AfterMap<SetTraceIdentifierAction>();
        }

        public void MapRecepcionDeCompra()
        {
            CreateMap<RecepcionDeCompraSave, TblRecepcionDeCompraEntity>();
            CreateMap<TblRecepcionDeCompraEntity, RecepcionDeCompraRead>();
        }

        public void MapProducto()
        {
            CreateMap<TblProductoEntity, ReadProductosEntity>()
                .ForMember(m => m.presentacion, m => m.Ignore())
                .AfterMap<SetTraceIdentifierAction>();
        }
    }
}
