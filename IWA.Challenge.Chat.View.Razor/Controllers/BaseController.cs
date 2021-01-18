using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace IWA.Challenge.Chat.View.Razor.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly string APIChildren = "";
        
        public BaseController(string serviceBase)
        {
            APIChildren = Startup.API + serviceBase;
        }

        protected List<object> ConverterParaFormatoJson(dynamic listaVM)
        {
            var lista = new List<object>();
            if(listaVM == null)
            {
                lista.Add(new
                {
                    Value = "0",
                    Text = "Sem Resultados"
                });
            }
            else
            {
                lista.Add(new
                {
                    Value = "0",
                    Text = "Selecione uma opção"
                });
                foreach (var item in listaVM)
                {
                    lista.Add(new
                    {
                        Value = item.Id.ToString(),
                        Text = item.Nome
                    });
                }
            }

            if (lista.Count == 0)
            {
                lista.Add(new
                {
                    Value = "0",
                    Text = "Sem Resultados"
                });
            }

            return lista;
        }

    }
}
