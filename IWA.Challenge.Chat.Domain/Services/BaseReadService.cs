﻿using IWA.Challenge.Chat.Domain.Entities;
using IWA.Challenge.Chat.Domain.Interfaces.Repositories;
using IWA.Challenge.Chat.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Domain.Services
{
    public class BaseReadService<T> : IBaseReadService<T> where T : BaseEntity
    {
        protected readonly IBaseReadRepository<T> _repositorio;

        public BaseReadService(IBaseReadRepository<T> repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _repositorio.GetAll();
        }

        public async Task<IEnumerable<T>> GetAllExpression(Expression<Func<T, bool>> expression)
        {
            return await _repositorio.GetAllExpression(expression);
        }

        public async Task<T> GetById(int id)
        {
            return await _repositorio.GetById(id);
        }
    }
}
