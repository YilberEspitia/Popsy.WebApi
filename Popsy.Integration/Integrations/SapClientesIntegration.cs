using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Integrations
{
    public class SapClientesIntegration : ISapClientesIntegration
    {
        public async Task<IEnumerable<dynamic>> GetSapClientes()
        {
            SapClientesEntity entity = new SapClientesEntity();
            List<SapClientesEntity> entityList = new List<SapClientesEntity>();
            string url = "https://FIORI.HELADOSPOPSY.COM:4430/sap/opu/odata/sap/Z_OK_CATALOGO_CLIENTES_CDS/Z_OK_CATALOGO_CLIENTES(p_start_date='20220911')/Set?$format=json";

            HttpMessageHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(url),
                Timeout = new TimeSpan(0, 2, 0)
            };

            // ... Use HttpClient.            
            HttpClient client = new HttpClient(handler);

            var byteArray = Encoding.ASCII.GetBytes("REPORTERIA.P:Popsy2022++**");
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

            HttpResponseMessage response = await client.GetAsync(url);
            HttpContent content = response.Content;
            if (response != null)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                dynamic myObject = JValue.Parse(jsonString);

                foreach (dynamic questions in myObject)
                {
                    foreach (dynamic d in questions)
                    {
                        dynamic updates = JsonConvert.DeserializeObject(JObject.Parse(d.ToString()).SelectToken("results").ToString());
                        foreach (var update in updates)
                        {
                            entity.id_Cliente = update.id_Cliente.ToString();
                            entity.Nombre1 = update.Nombre1.ToString();
                            entityList.Add(entity);
                        }
                    }
                }
            }
            return Array.Empty<dynamic>();
        }
    }
}