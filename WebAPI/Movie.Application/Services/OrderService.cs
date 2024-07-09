using System.Text;
using System.Text.Json;
using AutoMapper;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;
using RabbitMQ.Client;

namespace Movie.Application.Services
{
    public class OrderService : IOrderService
    {
        protected readonly IMapper _mapper;
        protected readonly IUserService _userService;

        public OrderService(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<bool> Create(CreateOrderDto createOrderDto)
        {
            try
            {
                var foundUserDTO = await _userService.ListAll<GetUserPaginatedDTO, FoundUserDTO>(null);

                var order = _mapper.Map<Order>(createOrderDto);

                order.Emails = foundUserDTO.Select(x => x.Email).ToList();

                var factory = new ConnectionFactory { HostName = "localhost" };
                using var connection = factory.CreateConnection();
                using var channel = connection.CreateModel();

                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = JsonSerializer.Serialize(order);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: string.Empty,
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);

                return true;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}