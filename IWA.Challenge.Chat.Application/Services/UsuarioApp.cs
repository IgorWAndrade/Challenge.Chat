﻿using AutoMapper;
using IWA.Challenge.Chat.Application.DTOs;
using IWA.Challenge.Chat.Application.Interfaces;
using IWA.Challenge.Chat.Domain.Entities;
using IWA.Challenge.Chat.Domain.Interfaces.Services;
using System;
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
                        Nome = obj.Nome
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
                            Nome = obj.Nome
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
    }
}