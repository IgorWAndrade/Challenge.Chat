﻿using IWA.Challenge.Chat.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IWA.Challenge.Chat.Infra.Data.Contexto
{
    public class BaseContexto : DbContext, IBaseContexto
    {
        protected IDbContextTransaction _contextoTransaction { get; set; }

        public BaseContexto(DbContextOptions<BaseContexto> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public async Task<IDbContextTransaction> StartTransaction()
        {
            if (_contextoTransaction == null)
            {
                _contextoTransaction = await this.Database.BeginTransactionAsync();
            }
            return _contextoTransaction;
        }

        public async Task RollBack()
        {
            if (_contextoTransaction != null)
            {
                await _contextoTransaction.RollbackAsync();
            }
        }

        public async Task Commit()
        {
            await Save();
            await PrepareCommit();
        }

        private async Task PrepareCommit()
        {
            if (_contextoTransaction != null)
            {
                await _contextoTransaction.CommitAsync();
                await _contextoTransaction.DisposeAsync();
                _contextoTransaction = null;
            }
        }

        private async Task Save()
        {
            try
            {
                ChangeTracker.DetectChanges();
                await SaveChangesAsync();
            }
            catch (Exception ex)
            {
                await RollBack();
                throw new Exception(ex.Message);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.ApplyConfiguration(new EntityMap());
        }
    }
}
