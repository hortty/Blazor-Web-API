using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : EntityBase
    {
        public Task<TEntity> Create(TEntity entity);

        public Task<TEntity> Update(TEntity entity);

        public Task<TEntity> Delete(TEntity entity);

        public Task<IEnumerable<TEntity>> ListAll<TInputDto>(TInputDto inputDto) where TInputDto: class;

        public Task<TEntity> ListById(TEntity entity);
    }
}
