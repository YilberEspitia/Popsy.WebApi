using System.Net.Http.Headers;
using System.Text;
using System.Xml;

using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

using Popsy.Interfaces;
using Popsy.Objects;
using Popsy.Settings;

namespace Popsy.Integrations
{
    public class SapSyncIntegration : IntegracionBase, ISapSyncIntegration
    {
        private readonly IntegracionPopsySettings _settings;
        /// <summary>
        /// Logger.
        /// </summary>
        private readonly ILogger<SapSyncIntegration> _logger;

        public SapSyncIntegration(IntegracionPopsySettings settings, ILogger<SapSyncIntegration> logger)
        {
            _settings = settings;
            _logger = logger;
        }

        async Task<ResponseSAP<ResultOrdenDeCompra>?> ISapSyncIntegration.GetOrdenesDeCompra(String codigo_almacen)
        {
            String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            String url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiOrdenDeCompra, codigo_almacen, _settings.SapClient));
            return await base.GetObjectResponse<ResponseSAP<ResultOrdenDeCompra>>(url, new AuthenticationHeaderValue(_settings.AuthenticationType, credentials));
        }

        async Task<ResponseSAP<ResultStockTeoricoDeInventario>?> ISapSyncIntegration.GetStockTeoricoDeInventario(String codigo_almacen)
        {
            String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            String url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiStockTeoricoInventario, codigo_almacen, _settings.SapClient));
            return await base.GetObjectResponse<ResponseSAP<ResultStockTeoricoDeInventario>>(url, new AuthenticationHeaderValue(_settings.AuthenticationType, credentials));
        }

        async Task<ResponseSAP<ResultProveedorRecepcion>?> ISapSyncIntegration.GetProveedoresRecepcion()
        {
            String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            String url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiProveedorRecepcion, _settings.SapClient));
            return await base.GetObjectResponse<ResponseSAP<ResultProveedorRecepcion>>(url, new AuthenticationHeaderValue(_settings.AuthenticationType, credentials));
        }

        async Task<ResponseSAP<ResultUnidadInventarioDos>?> ISapSyncIntegration.GetUnidadInventarioDos()
        {
            String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            String url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiFacConversionInventario, _settings.SapClient));
            return await base.GetObjectResponse<ResponseSAP<ResultUnidadInventarioDos>>(url, new AuthenticationHeaderValue(_settings.AuthenticationType, credentials));
        }

        async Task<ResponseSAP<ResultStockDia>?> ISapSyncIntegration.GetStockDia(String date, String codigo_almacen)
        {
            String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            String url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiStockDiario, date, codigo_almacen));
            return await base.GetObjectResponse<ResponseSAP<ResultStockDia>>(url, new AuthenticationHeaderValue(_settings.AuthenticationType, credentials));
        }

        async Task<ResponseRecepcionDeCompraXMLObject> ISapSyncIntegration.EnviaRecepcionDeCompra(XMLSoMvt xmlObject, Guid recepcion_compra_id)
        {
            String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            String url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiRecepcionDeCompra, _settings.SapClient));
            XmlDocument? xmlDocument = JsonConvert.DeserializeXmlNode(System.Text.Json.JsonSerializer.Serialize(xmlObject));
            HttpMessageHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            String xmlString = this.GetSoapRequest(xmlDocument);
            _logger.LogInformation($"Objeto enviado a SAP: {xmlString}");
            HttpContent content = new StringContent(xmlString, System.Text.Encoding.UTF8, "application/soap+xml");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_settings.AuthenticationType, credentials);

            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            String responseTest = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"Objeto recibido de SAP: {responseTest}");
            return new ResponseRecepcionDeCompraXMLObject
            {
                XML = xmlString,
                Respuestas = this.GetSoapResponse(responseTest, recepcion_compra_id)
            };
        }

        async Task<ResponseRecepcionDeCompraXMLObject> ISapSyncIntegration.EnviaRecepcionDeCompra(String xmlString, Guid recepcion_compra_id)
        {
            String credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            String url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiRecepcionDeCompra, _settings.SapClient));
            HttpMessageHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            _logger.LogInformation($"Objeto enviado a SAP: {xmlString}");
            HttpContent content = new StringContent(xmlString, System.Text.Encoding.UTF8, "application/soap+xml");
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_settings.AuthenticationType, credentials);

            HttpResponseMessage response = await httpClient.PostAsync(url, content);
            String responseTest = await response.Content.ReadAsStringAsync();
            _logger.LogInformation($"Objeto recibido de SAP: {responseTest}");
            return new ResponseRecepcionDeCompraXMLObject
            {
                XML = xmlString,
                Respuestas = this.GetSoapResponse(responseTest, recepcion_compra_id)
            };
        }

        private String GetSoapRequest(XmlDocument? xmlDocument)
        {
            String xmlString = xmlDocument is not null ? xmlDocument.OuterXml : String.Empty;
            // Construye el XML completo con las etiquetas adicionales
            return $"<soap:Envelope xmlns:soap=\"http://www.w3.org/2003/05/soap-envelope\" xmlns:urn=\"urn:sap-com:document:sap:soap:functions:mc-style\">" +
                                  $"<soap:Header/>" +
                                  $"<soap:Body>" +
                                  $"<urn:ZfmMovInventario>" +
                                  $"<Date>{DateTime.Now:yyyy-MM-dd}</Date>" +
                                  $"<Time>{DateTime.Now:HH:mm:ss}</Time>" +
                                  $"<Uuid>01</Uuid>" +
                                  $"{xmlString}" +
                                  $"</urn:ZfmMovInventario>" +
                                  $"</soap:Body>" +
                                  $"</soap:Envelope>";
        }

        private IEnumerable<ResponseRecepcionDeCompraObject> GetSoapResponse(String soapResponse, Guid recepcion_compra_id)
        {
            ISet<ResponseRecepcionDeCompraObject> response = new HashSet<ResponseRecepcionDeCompraObject>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(soapResponse);

            XmlNamespaceManager namespaceManager = new XmlNamespaceManager(xmlDoc.NameTable);
            namespaceManager.AddNamespace("env", "http://www.w3.org/2003/05/soap-envelope");
            namespaceManager.AddNamespace("n0", "urn:sap-com:document:sap:soap:functions:mc-style");

            XmlNodeList? itemNodes = xmlDoc.SelectNodes("//env:Body/n0:ZfmMovInventarioResponse/Return/item", namespaceManager);
            if (itemNodes is not null)
            {
                int i = 0;
                foreach (XmlNode itemNode in itemNodes)
                {
                    i++;
                    int Number = default;
                    int.TryParse(itemNode.SelectSingleNode("Number")?.InnerText, out Number);
                    int LogMsgNo = default;
                    int.TryParse(itemNode.SelectSingleNode("LogMsgNo")?.InnerText, out LogMsgNo);
                    int Row = default;
                    int.TryParse(itemNode.SelectSingleNode("Row")?.InnerText, out Row);
                    response.Add(new ResponseRecepcionDeCompraObject
                    {
                        recepcion_compra_id = recepcion_compra_id,
                        Type = itemNode.SelectSingleNode("Type")?.InnerText,
                        Id = itemNode.SelectSingleNode("Id")?.InnerText,
                        Number = Number,
                        Message = itemNode.SelectSingleNode("Message")?.InnerText,
                        LogNo = itemNode.SelectSingleNode("LogNo")?.InnerText,
                        LogMsgNo = LogMsgNo,
                        MessageV1 = itemNode.SelectSingleNode("MessageV1")?.InnerText,
                        MessageV2 = itemNode.SelectSingleNode("MessageV2")?.InnerText,
                        MessageV3 = itemNode.SelectSingleNode("MessageV3")?.InnerText,
                        MessageV4 = itemNode.SelectSingleNode("MessageV4")?.InnerText,
                        Parameter = itemNode.SelectSingleNode("Parameter")?.InnerText,
                        Field = itemNode.SelectSingleNode("Field")?.InnerText,
                        System = itemNode.SelectSingleNode("System")?.InnerText,
                        Orden = i,
                        Activo = true
                    });
                }
            }
            return response;
        }
    }
}
