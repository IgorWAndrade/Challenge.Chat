using AutoMapper;
using IWA.Challenge.Chat.Application.DTOs;
using IWA.Challenge.Chat.Application.Interfaces;
using IWA.Challenge.Chat.Domain.Entities;
using IWA.Challenge.Chat.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Application.Services
{
    public class UsuarioApp : BaseServiceApp<Usuario>, IUsuarioApp
    {
        private readonly IUsuarioService _usuarioService;
        public UsuarioApp(IUsuarioService usuarioService, IMapper mapper) : base(usuarioService, mapper)
        {
            _usuarioService = usuarioService;
        }

        public async Task<ResponseDTO> Add(UsuarioAddDTO usuario)
        {
            var response = new ResponseDTO();
            try
            {
                var obj = _mapper.Map<Usuario>(usuario);

                if (obj.Anonimo)
                {
                    obj.Nome = "Anonimo " + Guid.NewGuid();

                    var result = await _usuarioService.Add(obj);
                    response.Sucesso = (result > 0) ? true : false;
                    response.Mensagem = "Usuario Inserido com Sucesso.";
                    response.Data = new
                    {
                        Id = obj.Id
                    };
                }
                else
                {
                    if (!_usuarioService.ExisteNome(obj.Nome))
                    {
                        var result = await _usuarioService.Add(obj);
                        response.Sucesso = (result > 0) ? true : false;
                        response.Mensagem = "Usuario Inserido com Sucesso.";
                        response.Data = new
                        {
                            Id = obj.Id
                        };
                    }
                    else
                    {
                        response.Sucesso = false;
                        response.Mensagem = "Nome ou Apelido já existente.";
                    }
                }
                return response;
            }
            catch
            {
                response.Sucesso = false;
                response.Mensagem = "Ocorreu um Erro com Servidor. Contate a equipe de TI.";
                return response;
            }

        }

        public async Task<ResponseDTO> GetById(int id)
        {
            var response = new ResponseDTO();
            try
            {
                var obj = await _usuarioService.GetById(id);

                //Caso tenha apelido será retornado este
                if (!string.IsNullOrEmpty(obj.Apelido))
                {
                    obj.Nome = obj.Apelido;
                }

                response.Sucesso = true;
                response.Data = new
                {
                    Id = obj.Id,
                    Nome = obj.Nome
                };
            }
            catch
            {
                response.Sucesso = false;
                response.Mensagem = "Ocorreu um Erro com Servidor. Contate a equipe de TI.";
            }
            return response;
        }

        public async Task<ResponseDTO> GetByName(string name)
        {
            var response = new ResponseDTO();
            try
            {
                var lista = await _usuarioService.GetAllExpression(x => x.Anonimo == false);

                // Filtrar por 10 primeiros
                if (string.IsNullOrEmpty(name))
                {
                    lista = lista.Take(10).OrderBy(x => x.Nome).ToList();
                }
                // Filtrar Por Nome
                else
                {
                    lista = lista.Where(x => x.Nome.ToLower().Contains(name.ToLower())).OrderBy(x => x.Nome).Take(10).ToList();
                }

                var listaObj = new List<object>();
                foreach (var item in lista)
                {
                    listaObj.Add(new
                    {
                        Id = item.Id,
                        Nome = item.Nome
                    });
                }
                response.Sucesso = true;
                response.Data = listaObj;
            }
            catch
            {
                response.Sucesso = false;
                response.Mensagem = "Ocorreu um Erro com Servidor. Contate a equipe de TI.";
            }
            return response;
        }

        public async Task<ResponseDTO> GetAll()
        {
            var response = new ResponseDTO();
            try
            {
                var lista = await _usuarioService.GetAllExpression(x => x.Nome != "");

                var listaObj = new List<object>();
                foreach (var item in lista.OrderBy(x => x.Nome))
                {
                    listaObj.Add(new
                    {
                        Id = item.Id,
                        Nome = item.Nome
                    });
                }
                response.Sucesso = true;
                response.Data = listaObj;
            }
            catch
            {
                response.Sucesso = false;
                response.Mensagem = "Ocorreu um Erro com Servidor. Contate a equipe de TI.";
            }
            return response;
        }
    }
}
