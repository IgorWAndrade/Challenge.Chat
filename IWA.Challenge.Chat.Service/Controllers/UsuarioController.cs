using IWA.Challenge.Chat.Application.DTOs;
using IWA.Challenge.Chat.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Service.Controllers
{
    public class UsuarioController : BaseController
    {
        private readonly IUsuarioApp _usuarioApp;

        public UsuarioController(IUsuarioApp usuarioApp)
        {
            _usuarioApp = usuarioApp;
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Post(UsuarioAddDTO usuario)
        {
            var result = await _usuarioApp.Add(usuario);
            if (result.Sucesso)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status100Continue)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _usuarioApp.GetById(id);
            if (result.Sucesso)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
