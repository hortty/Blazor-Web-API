using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class ShoppingCartService : GenericService<ShoppingCart, IShoppingCartRepository>, IShoppingCartService
    {
        public ShoppingCartService(IShoppingCartRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}