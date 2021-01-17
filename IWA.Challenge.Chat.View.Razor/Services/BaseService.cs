using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace IWA.Challenge.Chat.View.Razor.Services
{
    public abstract class BaseService
    {
        protected StringContent ConverterObjetoParaJson(dynamic obj)
        {
            return new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
        }
    }
}
