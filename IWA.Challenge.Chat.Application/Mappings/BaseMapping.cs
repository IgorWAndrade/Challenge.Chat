using AutoMapper;
using IWA.Challenge.Chat.Application.DTOs;
using IWA.Challenge.Chat.Domain.Entities;

namespace IWA.Challenge.Chat.Application.Mappings
{
    public class BaseMapping : Profile
    {
        public BaseMapping()
        {
            CreateMap<Usuario, UsuarioAddDTO>().ReverseMap();
        }
    }
}
