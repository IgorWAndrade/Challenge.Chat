using IWA.Challenge.Chat.View.Razor.ViewModels.Usuario;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
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

        public async Task<UsuarioGet> GetById(string url)
        {
            var uri = new Uri(url);
            var returnData = await _http.GetAsync(uri);
            var result = await returnData.Content.ReadAsStringAsync();
            var data = JsonConvert.SerializeObject(ConverterJsonParaObjeto(result).Data);
            return JsonConvert.DeserializeObject<UsuarioGet>(data);
        }

        public async Task<IEnumerable<UsuarioGet>> GetByName(string url)
        {
            var uri = new Uri(url);
            var returnData = await _http.GetAsync(uri);
            var result = await returnData.Content.ReadAsStringAsync();
            var data = JsonConvert.SerializeObject(ConverterJsonParaObjeto(result).Data);
            return JsonConvert.DeserializeObject<IEnumerable<UsuarioGet>>(data);
        }

        public async Task<IEnumerable<UsuarioGet>> GetAll(string url)
        {
            var uri = new Uri(url);
            var returnData = await _http.GetAsync(uri);
            var result = await returnData.Content.ReadAsStringAsync();
            var data = JsonConvert.SerializeObject(ConverterJsonParaObjeto(result).Data);
            return JsonConvert.DeserializeObject<IEnumerable<UsuarioGet>>(data);
        }
    }
}
