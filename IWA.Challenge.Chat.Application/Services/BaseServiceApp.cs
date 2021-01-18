using AutoMapper;
using IWA.Challenge.Chat.Application.Interfaces;
using IWA.Challenge.Chat.Domain.Entities;
using IWA.Challenge.Chat.Domain.Interfaces.Services;

namespace IWA.Challenge.Chat.Application.Services
{
    public class BaseServiceApp<T> : IBaseApp<T> where T : BaseEntity
    {
        protected readonly IBaseService<T> _service;
        protected readonly IMapper _mapper;

        public BaseServiceApp(
            IBaseService<T> service,
            IMapper mapper) : base()
        {
            _service = service;
            _mapper = mapper;
        }
    }
}
