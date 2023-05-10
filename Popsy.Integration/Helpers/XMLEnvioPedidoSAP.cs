using System.Xml.Serialization;

using Popsy.Entities;
using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Helpers
{
    public class XMLEnvioPedidoSAP
    {
        private IVistaPedidosPuntoVentaRepository _repoPedidosPuntoVenta;
        private IProductosRepository _repoProductos;
        private IVistaProductoFactoresConversionRepository _repoProductoFactores;

        public XMLEnvioPedidoSAP(IVistaPedidosPuntoVentaRepository repoPedidosPuntoVenta
        , IProductosRepository repoProductos
        , IVistaProductoFactoresConversionRepository repoProductoFactores)
        {
            _repoPedidosPuntoVenta = repoPedidosPuntoVenta;
            _repoProductoFactores = repoProductoFactores;
            _repoProductos = repoProductos;
        }

        public async Task<ZMF_PUNTO_VENTA> CargarInfoXML(List<TblProductosPedidosEntity> infoList, string TipoDocumento, Guid pedido_id)
        {
            VistaPedidosPuntoVentaEntity puntoVentaInfo = await _repoPedidosPuntoVenta.GetVistaPedidosPuntoVenta(pedido_id);

            ZMF_PUNTO_VENTA resultado = new ZMF_PUNTO_VENTA();
            List<item> itemList = new List<item>();
            int PREQ_ITEM_INICIAL = 10;
            string Planta = TipoDocumento == "NB" ? puntoVentaInfo.codigo_punto_venta : ""; //Puntos_Venta.Codigo, si es traslado queda en blanco ""
            string CentroCostos = puntoVentaInfo.centro_cs; //Puntos_Venta.Centro_CS
            string Almacen = puntoVentaInfo.almacen_cs; //Puntos_Venta.Almacen.CS
            string Doc_CS = puntoVentaInfo.doc_cs; //Puntos_Venta.Doc_CS
            string OrdenCompra = TipoDocumento == "NB" ? "x" : "";
            string Organizacion = puntoVentaInfo.organizacion;

            resultado.ORDEN_COMPRA = OrdenCompra;
            resultado.SOLPED = "";
            resultado.TIPODOC_PT = Doc_CS;

            foreach (TblProductosPedidosEntity item in infoList)
            {
                //Validar obligatoriedad de todos los campos

                TblProductosEntity producto = await _repoProductos.GetProductosById(item.producto_id);
                VistaProductoFactoresConversionEntity factor = await _repoProductoFactores.GetProductoFactoresConversion(item.producto_id);

                string Categoria2 = producto.Categoria_Producto2; //Productos.Categoria_Producto2
                string Material = producto.codigo; //Productos.Codigo
                string UnidadMinima = factor.unidad_base; //Unidad Minima == Factores_Conversion
                string MatGroup = producto.Categoria_Producto1; //Productos.Categoria_Producto1                

                item itemCargue = new item();
                itemCargue.PREQ_ITEM = PREQ_ITEM_INICIAL.ToString();
                itemCargue.DOC_TYPE = TipoDocumento;
                itemCargue.PUR_GROUP = Categoria2;
                itemCargue.MATERIAL = Material;
                itemCargue.PLANT = Planta;
                itemCargue.STORE_LOC = "1000";
                itemCargue.DELIV_DATE = DateTime.Now.ToString("yyyy-MM-dd"); //Pendiente formato
                itemCargue.QUANTITY = item.cantidad.ToString();
                itemCargue.UNIT = UnidadMinima;
                itemCargue.C_AMT_BAPI = "0";
                itemCargue.PURCH_ORG = Organizacion;
                itemCargue.MAT_GRP = MatGroup;
                itemCargue.PREQ_NAME = "";
                itemCargue.SUPPL_PLNT = CentroCostos;
                itemCargue.ALM_EMISOR = Almacen;
                itemList.Add(itemCargue);
                PREQ_ITEM_INICIAL = PREQ_ITEM_INICIAL + 10;
            }
            resultado.T_ITEMS = itemList;
            return resultado;
        }

        public string EnviarXMLPedido(ZMF_PUNTO_VENTA infoXML)
        {
            SOAP XMLEnvio = new SOAP();
            XMLEnvio.Body = infoXML;
            XMLEnvio.Head = "";
            //Ludwig Poner una URL dependiente del proyecto
            string FileName = @"F:\LUDWIG\POPSY\XML\test" + DateTime.Now.ToString("yyyyMMddhhss") + ".xml";
            string FileNameEditado = @"F:\LUDWIG\POPSY\XML\test" + DateTime.Now.ToString("yyyyMMddhhss") + "-1.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(SOAP));

            using (TextWriter writer = new StreamWriter(FileName))
            {
                serializer.Serialize(writer, XMLEnvio);
            }

            string textFile = File.ReadAllText(FileName);
            //Head
            textFile = textFile.Replace("<Head />", "<soap:Header/>");
            //Encabezado
            textFile = textFile.Replace("<SOAP xmlns:xsi=", "<soap:Envelope xmlns:soap=");
            textFile = textFile.Replace("http://www.w3.org/2001/XMLSchema-instance", "http://www.w3.org/2003/05/soap-envelope");
            textFile = textFile.Replace("xmlns:xsd=", "xmlns:urn=");
            textFile = textFile.Replace("http://www.w3.org/2001/XMLSchema", "urn:sap-com:document:sap:rfc:functions");
            //Cuerpo
            textFile = textFile.Replace("<Body>", "<soap:Body><urn:ZMF_PUNTO_VENTA>");
            textFile = textFile.Replace("</Body>", "</urn:ZMF_PUNTO_VENTA></soap:Body>");
            textFile = textFile.Replace("</SOAP>", "</soap:Envelope>");
            textFile = textFile.Replace(" xsi:nil=\"true\" ", "");
            File.WriteAllText(FileNameEditado, textFile);
            return FileName;
        }
    }
}