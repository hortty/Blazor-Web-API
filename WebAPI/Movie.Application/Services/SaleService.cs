using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class SaleService : GenericService<Sale, ISaleRepository>, ISaleService
    {
        public SaleService(ISaleRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}