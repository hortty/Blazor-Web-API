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
        protected readonly IShoppingCartRepository _shoppingCartRepository;
        public ShoppingCartService(IShoppingCartRepository repository, IMapper mapper, IShoppingCartRepository shoppingCartRepository) : base(repository, mapper)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }

        public async Task<ShoppingCart> GetShoppingCartByUserId(Guid userId)
        {
            var shoppingCart = await _shoppingCartRepository.GetShoppingCartByUserId(userId);

            if (shoppingCart == null) throw new Exception("Carrinho não encontrado");

            return shoppingCart;
        }
    }
}