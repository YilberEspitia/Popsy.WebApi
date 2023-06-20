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
            this.MapInventario();
        }

        public void MapProveedorRecepcion()
        {
            CreateMap<ProveedorRecepcionObject, TblProveedorRecepcionEntity>().ReverseMap();
        }

        public void MapInventario()
        {
            CreateMap<StockTeoricoInventarioObject, TblStockTeoricoInventariosDos>().ReverseMap();
            CreateMap<StockFechaObject, TblStockAFechaEntity>().ReverseMap();
            CreateMap<UnidadInventarioDosObject, TblUnidadInventarioDos>().ReverseMap();
            CreateMap<TblTipoInventarioEntity, TipoInventarioRead>();
            CreateMap<InventarioConteoObject, TblInventarioConteo2Entity>().ReverseMap();
        }

        public void MapOrdenDeCompra()
        {
            CreateMap<OrdenDeCompraSave, TblOrdenDeCompraEntity>()
                .ForMember(m => m.detalles_ordenes_de_compra, m => m.Ignore());
            CreateMap<DetalleOrdenDeCompraSave, TblDetalleOrdenDeCompraEntity>();
            CreateMap<TblOrdenDeCompraEntity, OrdenDeCompraRead>();
            CreateMap<TblDetalleOrdenDeCompraEntity, DetalleOrdenDeCompraRead>()
                .AfterMap<SetTraceIdentifierAction>();
            CreateMap<TblPuntoVentaEntity, ReadPuntoVenta>()
                .AfterMap<SetTraceIdentifierAction>();
        }

        public void MapRecepcionDeCompra()
        {
            CreateMap<RecepcionDeCompraSave, TblRecepcionDeCompraEntity>()
                .ForMember(m => m.recepciones_compras_detalles, m => m.Ignore());
            CreateMap<TblRecepcionDeCompraEntity, RecepcionDeCompraRead>();
            CreateMap<RecepcionDeCompraDetalleObject, TblRecepcionDeCompraDetalleEntity>().ReverseMap();
            CreateMap<ResponseRecepcionDeCompraObject, TblResponseRecepcionDeCompraEntity>().ReverseMap();
        }

        public void MapProducto()
        {
            CreateMap<TblProductoEntity, ReadProductosEntity>()
                .AfterMap<SetTraceIdentifierAction>();
        }
    }
}
