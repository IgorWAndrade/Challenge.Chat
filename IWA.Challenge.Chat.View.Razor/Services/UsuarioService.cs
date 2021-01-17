using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.View.Razor.Services
{
    public class UsuarioService : BaseService
    {
        private readonly HttpClient _http;

        public UsuarioService(IHttpClientFactory clientFactory)
        {
            _http = clientFactory.CreateClient();
        }

        public async Task<object> Post(string url, dynamic content)
        {
            var uri = new Uri(url);
            var returnData = await _http.PostAsync(uri, ConverterObjetoParaJson(content));
            return await returnData.Content.ReadAsStringAsync();
        }
    }
}
