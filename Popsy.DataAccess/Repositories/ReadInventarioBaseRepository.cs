using Microsoft.EntityFrameworkCore;

using Popsy.Entities;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Repositories
{
    public class ReadInventarioBaseRepository : IReadInventarioBaseRepository
    {
        private readonly PopsyDbContext _context;

        public ReadInventarioBaseRepository(PopsyDbContext context)
        {
            _context = context;
        }
        public async Task<List<ReadInventarioBaseEntity>> GetInventarioBase(Guid punto_venta_id)
        {
            List<ReadInventarioBaseEntity> infoList = new List<ReadInventarioBaseEntity>();
            List<VistaCategoriasProductosEntity> vistaCategorias = await _context.VistaCategoriasProductos.ToListAsync();

            foreach (VistaCategoriasProductosEntity categoria in vistaCategorias)
            {
                ReadInventarioBaseEntity info = new ReadInventarioBaseEntity();
                List<ReadProductosEntity> productoList = new List<ReadProductosEntity>();
                info.categoria_id = categoria.categoria_id;
                info.categoria_nombre = categoria.categoria_nombre;
                var productosPuntoVenta = _context.VistaProductosParaInventario.Where(l => l.categoria_id == categoria.categoria_id && l.punto_venta_id == punto_venta_id).Select(i => new { i.producto_id, i.nombre_producto }).Distinct().ToList();
                foreach (var producto in productosPuntoVenta)
                {
                    ReadProductosEntity productoRead = new ReadProductosEntity();
                    productoRead.producto_id = producto.producto_id;
                    productoRead.producto_nombre = producto.nombre_producto;
                    productoRead.cantidad = 0;
                    productoList.Add(productoRead);
                    var presentacionProductos = _context.VistaProductosParaInventario.Where(l => l.categoria_id == categoria.categoria_id && l.punto_venta_id == punto_venta_id && l.producto_id == producto.producto_id).Select(i => new { i.contador, i.unidad_medida_alter, i.unidad_base }).Distinct().ToList();
                    List<ReadPresentacionEntity> presentacionList = new List<ReadPresentacionEntity>();
                    foreach (var presentacion in presentacionProductos)
                    {
                        ReadPresentacionEntity presentacionRead = new ReadPresentacionEntity();
                        presentacionRead.cantidad_unidad_minima = presentacion.contador;
                        presentacionRead.unidad_minima = false;
                        presentacionRead.presentacion_id = presentacion.unidad_medida_alter;
                        presentacionRead.presentacion_nombre = presentacion.unidad_base;
                        presentacionList.Add(presentacionRead);
                    }
                    productoRead.presentacion = presentacionList;
                }
                info.productos = productoList;
                infoList.Add(info);
            }
            // if(vista!=null)
            // {

            //     var categoriasProductos = await _context.VistaProductosParaInventario.Where(l=>l.categoria_id==categoria_id && l.punto_venta_id==punto_venta && l.factor_conversion.Replace(" ","").Replace("-","")== sub_categoria).Select(i => new { i.categoria_id, i.punto_venta_id, i.factor_conversion }).Distinct().ToListAsync();
            //     List<ReadFactorConversionEntity> factorConversionList = new List<ReadFactorConversionEntity>();
            //     info.categoria_id=categoria_id;
            //     info.categoria_nombre=vista.categoria_nombre;
            //     foreach(var categorias in categoriasProductos)
            //     {
            //         List<VistaPuntosVentaBodegasEntity> bodegaspuntoVenta = await _context.VistaPuntosVentaBodegas.Where(l=>l.punto_venta_id==punto_venta).Distinct().ToListAsync();
            //         List<ReadBodegaEntity> bodegasList = new List<ReadBodegaEntity>();                
            //         ReadFactorConversionEntity factorConversion = new ReadFactorConversionEntity();
            //         factorConversion.factor_conversion_id=categorias.factor_conversion.Replace(" ","").Replace("-","");
            //         factorConversion.factor_conversion_nombre=categorias.factor_conversion;
            //         foreach(var bodegas in bodegaspuntoVenta)
            //         {
            //             ReadBodegaEntity bodega = new ReadBodegaEntity();
            //             bodega.bodega_id=bodegas.bodega_id;
            //             bodega.bodega_nombre=bodegas.nombre_bodega;

            //             bodega.presentacion = presentacionList;
            //             bodegasList.Add(bodega);
            //         }
            //         factorConversion.bodegas = bodegasList;
            //         factorConversionList.Add(factorConversion);
            //     }
            //     info.factor_conversion = factorConversionList;
            // }
            return infoList;
        }
    }
}