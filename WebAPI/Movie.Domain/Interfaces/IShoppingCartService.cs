using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie.Domain.Interfaces
{
    public interface IShoppingCartService : IGenericService
    {
        public Task<ShoppingCart> GetShoppingCartByUserId(Guid userId);
    }
}