using System.Net.Http.Headers;
using System.Text;

using Popsy.Interfaces;
using Popsy.Objects;
using Popsy.Settings;

namespace Popsy.Integrations
{
    public class SapRecepcionDeComprasIntegration : IntegracionBase, ISapRecepcionDeComprasIntegration
    {
        private readonly IntegracionPopsySettings _settings;

        public SapRecepcionDeComprasIntegration(IntegracionPopsySettings settings)
        {
            _settings = settings;
        }

        async Task<ResponseSAP<ResultOrdenDeCompra>> ISapRecepcionDeComprasIntegration.SyncOrdenesDeCompra(string codigo_almacen)
        {
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            string url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiOrdenDeCompra, codigo_almacen, _settings.SapClient));
            return await base.GetObjectResponse<ResponseSAP<ResultOrdenDeCompra>>(url, new AuthenticationHeaderValue(_settings.AuthenticationType, credentials));
        }

        async Task<ResponseSAP<ResultProveedorRecepcion>> ISapRecepcionDeComprasIntegration.SyncProveedoresRecepcion()
        {
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            string url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiProveedorRecepcion, _settings.SapClient));
            return await base.GetObjectResponse<ResponseSAP<ResultProveedorRecepcion>>(url, new AuthenticationHeaderValue(_settings.AuthenticationType, credentials));
        }

        async Task<string> ISapRecepcionDeComprasIntegration.EnviaRecepcionDeCompra()
        {
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_settings.Username + ":" + _settings.Password));
            string url = String.Concat(String.Format(_settings.EndPoint, _settings.Ambiente), String.Format(_settings.ApiOrdenDeCompra, _settings.SapClient));
            HttpMessageHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(_settings.AuthenticationType, credentials);

            HttpResponseMessage response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
