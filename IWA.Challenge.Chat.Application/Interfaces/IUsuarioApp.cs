﻿using IWA.Challenge.Chat.Application.DTOs;
using IWA.Challenge.Chat.Domain.Entities;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Application.Interfaces
{
    public interface IUsuarioApp : IBaseApp<Usuario>
    {
        Task<ResponseDTO> Add(UsuarioAddDTO usuario);
        Task<ResponseDTO> GetById(int id);
        Task<ResponseDTO> GetByName(string name);
        Task<ResponseDTO> GetAll();
    }
}
