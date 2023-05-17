using System.Net.Http.Headers;
using System.Text.Json;

namespace Popsy.Integrations
{
    public abstract class IntegracionBase
    {
        protected async Task<string> GetStringResponse(string url, AuthenticationHeaderValue? authenticationHeader = default)
        {
            HttpMessageHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            if (authenticationHeader != default)
                httpClient.DefaultRequestHeaders.Authorization = authenticationHeader;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
        protected async Task<T?> GetObjectResponse<T>(string url, AuthenticationHeaderValue? authenticationHeader = default)
            where T : class
        {
            HttpMessageHandler handler = new HttpClientHandler();
            HttpClient httpClient = new HttpClient(handler);
            if (authenticationHeader != default)
                httpClient.DefaultRequestHeaders.Authorization = authenticationHeader;
            HttpResponseMessage response = await httpClient.GetAsync(url);
            return JsonSerializer.Deserialize<T>(await response.Content.ReadAsStringAsync());
        }
    }
}
