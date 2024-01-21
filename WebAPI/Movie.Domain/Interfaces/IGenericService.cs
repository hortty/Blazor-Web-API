using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface IGenericService
    {
        public Task<TOutputDto> Create<TInputDto, TOutputDto>(TInputDto inputDto) where TInputDto: class where TOutputDto : class ;

        public Task<TOutputDto> Update<TInputDto, TOutputDto>(TInputDto inputDto) where TInputDto: class where TOutputDto : class;

        public Task<TOutputDto> Delete<TInputDto, TOutputDto>(TInputDto inputDto) where TInputDto: class where TOutputDto : class;

        public Task<IEnumerable<TOutputDto>> ListAll<TOutputDto>() where TOutputDto : class;

        public Task<TOutputDto> ListById<TInputDto, TOutputDto>(TInputDto inputDto) where TInputDto: class where TOutputDto : class;
    }
}
