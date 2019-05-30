﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Exchanger.Framework.Entities;
using Exchanger.Framework.Specifications;

namespace Exchanger.Framework.Repositories
{
    public interface IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> GetAsync(params object[] keys);

        Task<List<TEntity>> GetAllAsync();

        Task<List<TEntity>> QueryAsync(BaseSpecification<TEntity> specification);

        Task<bool> ExistsAsync(BaseSpecification<TEntity> specification);

        Task<long> CountAsync();

        Task<long> CountAsync(BaseSpecification<TEntity> specification);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task CommitAsync();
    }
}
