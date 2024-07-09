using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Models;

namespace Movie.Domain.Interfaces
{
    public interface IOrderService
    {
        public Task<bool> Create(CreateOrderDto createOrderDto);
    }
}
