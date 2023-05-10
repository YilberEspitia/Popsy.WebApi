using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Popsy.Interfaces;
using Popsy.Objects;

namespace Popsy.Integrations
{
    public class SapMaterialesIntegration : ISapMaterialesIntegration
    {
        public async Task<IEnumerable<dynamic>> GetSapMateriales()
        {
            SapMaterialesEntity entity = new SapMaterialesEntity();
            List<SapMaterialesEntity> entityList = new List<SapMaterialesEntity>();
            string url = "https://FIORI.HELADOSPOPSY.COM:4430/sap/opu/odata/sap/Z_OK_MATERIALES_CDS/Z_OK_MATERIALES(p_start_date='20220511')/Set?$format=json";

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
                        List<Dictionary<string, string>> records = new List<Dictionary<string, string>>();
                        Dictionary<string, string> fields = new Dictionary<string, string>();
                        dynamic updates = JsonConvert.DeserializeObject(JObject.Parse(d.ToString()).SelectToken("results").ToString());
                        foreach (var update in updates)
                        {
                            entity.CodigoProducto = update.CodigoProducto.ToString();
                            entity.Description = update.Description.ToString();
                            entityList.Add(entity);
                        }
                    }
                }
            }
            return null;
        }
    }
}