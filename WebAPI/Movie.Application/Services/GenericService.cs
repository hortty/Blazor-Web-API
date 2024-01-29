using AutoMapper;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Services
{
    public class GenericService<TEntity, TRepository> : IGenericService
        where TEntity : EntityBase
        where TRepository : IGenericRepository<TEntity>
    {
        private readonly TRepository _repository;
        private readonly IMapper _mapper;

        public GenericService(TRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async virtual Task<TOutputDto> Create<TInputDto, TOutputDto>(TInputDto inputDto) 
        where TInputDto : class 
        where TOutputDto : class
        {
            var entity = _mapper.Map<TEntity>(inputDto);

            entity.CreationDate = DateTime.UtcNow;
            entity.Ativo = true;

            var createdEntity = await _repository.Create(entity);

            var outputDto = _mapper.Map<TOutputDto>(createdEntity);

            return outputDto;
        }

        public async virtual Task<TOutputDto> Delete<TInputDto, TOutputDto>(TInputDto inputDto)
        where TInputDto : class 
        where TOutputDto : class
        {
            var entity = _mapper.Map<TEntity>(inputDto);

            var deletedEntity = await _repository.Delete(entity);

            var outputDto = _mapper.Map<TOutputDto>(deletedEntity);

            return outputDto;
        }

        public async virtual Task<IEnumerable<TOutputDto>> ListAll<TInputDto, TOutputDto>(TInputDto inputDto)
        where TOutputDto : class
        where TInputDto : class
        {
            var entitiesList = await _repository.ListAll<TInputDto>(inputDto);

            var outputDto = _mapper.Map<IEnumerable<TOutputDto>>(entitiesList);

            return outputDto;
        }

        public async virtual Task<TOutputDto> ListById<TInputDto, TOutputDto>(TInputDto inputDto)
        where TInputDto : class 
        where TOutputDto : class
        {
            var entity = _mapper.Map<TEntity>(inputDto);

            var foundEntity = await _repository.ListById(entity);

            var outputDto = _mapper.Map<TOutputDto>(foundEntity);

            return outputDto;
        }

        public async virtual Task<TOutputDto> Update<TInputDto, TOutputDto>(TInputDto inputDto)
        where TInputDto : class 
        where TOutputDto : class
        {
            var entity = _mapper.Map<TEntity>(inputDto);

            var updatedEntity = await _repository.Update(entity);

            var outputDto = _mapper.Map<TOutputDto>(updatedEntity);

            return outputDto;
        }
    }
}
