using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using AutoMapper;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Dtos.ShoppingCartMovieDto;
using Movie.Domain.Dtos.UserDto;
using Movie.Domain.Interfaces;
using Movie.Domain.Models;

namespace Movie.Application.Services
{
    public class CustomerService : GenericService<Customer, ICustomerRepository>, ICustomerService
    {
        protected readonly IUserService _userService;
        protected readonly ICustomerRepository _repository;
        protected readonly IMapper _mapper;
        protected readonly IShoppingCartService _shoppingCartService;

        public CustomerService(ICustomerRepository repository, IMapper mapper, IUserService userService, IShoppingCartService shoppingCartService) : base(repository, mapper)
        {
            _userService = userService;
            _repository = repository;
            _mapper = mapper;
            _shoppingCartService = shoppingCartService;
        }

        public async override Task<TOutputDto> Create<TInputDto, TOutputDto>(TInputDto inputDto)
        where TInputDto : class
        where TOutputDto : class
        {
            if (inputDto == null) throw new NullReferenceException(nameof(inputDto));

            CreateCustomerDto createCustomerDto = inputDto as CreateCustomerDto;

            CreateUserDto createUserDto = new CreateUserDto
            {
                Email = createCustomerDto.Email,
                PasswordHash = createCustomerDto.Password,
                Username = createCustomerDto.Login,
                Ativo = true,
                CreationDate = DateTime.UtcNow,
                Role = "DEFAULT"
            };

            //using(var transaction = new TransactionScope())
            //{
            try
            {
                var createdUser = await _userService.Create<CreateUserDto, CreatedUserDto>(createUserDto);

                if (createdUser == null) throw new Exception("Criação de User falhou");

                CreateShoppingCartDTO createShoppingCartDTO = new CreateShoppingCartDTO
                {
                    UserId = createdUser.Id
                };

                var createdShoppingCart = await _shoppingCartService.Create<CreateShoppingCartDTO, CreatedShoppingCartDTO>(createShoppingCartDTO);

                if (createdShoppingCart == null) throw new Exception("Criação do Carrinho falhou");

                createCustomerDto.UserId = createdUser.Id;

                var customer = _mapper.Map<Customer>(createCustomerDto);

                customer.Ativo = true;
                customer.CreationDate = DateTime.UtcNow;

                var createdCustomer = await _repository.Create(customer);

                if (createdCustomer == null) throw new Exception("Criação de Cliente falhou");
                //transaction.Complete();

                return createdCustomer as TOutputDto;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //}
        }
    }
}