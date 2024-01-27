using Microsoft.EntityFrameworkCore;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using Movie.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : EntityBase
    {
        private readonly DataContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public GenericRepository(DataContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async virtual Task<TEntity> Create(TEntity entity)
        {
            var createdEntity = await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return createdEntity.Entity;
        }

        public async virtual Task<TEntity> Delete(TEntity entity)
        {
            var foundEntity = await ListById(entity);

            if (foundEntity == null)
                throw new InvalidOperationException($"Entity not found.");

            var removedEntity = _dbSet.Remove(foundEntity);
            await _dbContext.SaveChangesAsync();

            return removedEntity.Entity;
        }

        public async virtual Task<IEnumerable<TEntity>> ListAll()
        {
            var foundEntities = await _dbSet.AsNoTracking().Skip(0).Take(10).ToListAsync();

            if (foundEntities.Equals(null))
                throw new InvalidOperationException($"Entities not found.");

            return foundEntities;
        }

        public async virtual Task<TEntity> ListById(TEntity entity)
        {
            var foundEntity = await _dbSet.FindAsync(entity.Id);

            if (foundEntity == null)
                throw new InvalidOperationException($"Entity not found.");

            return foundEntity;
        }

        public async virtual Task<TEntity> Update(TEntity entity)
        {
            var foundEntity = await _dbSet.FindAsync(entity.Id);

            if (foundEntity == null)
            {
                throw new InvalidOperationException($"Entity not found.");
            }

            var props = entity.GetType().GetProperties();

            foreach(var prop in props)
            {
                var propValue = prop.GetValue(entity);

                if((propValue is not int && propValue != null) || (propValue is int && (int)propValue != 0))
                {
                    foundEntity!.GetType()?.GetProperty(prop.Name)?.SetValue(foundEntity, propValue);
                }
                
            }

            _dbContext.Entry(foundEntity).CurrentValues.SetValues(foundEntity!);
            var updatedEntity = _dbContext.Entry(foundEntity).Entity;
            await _dbContext.SaveChangesAsync();

            return updatedEntity;
        }
    }
}
