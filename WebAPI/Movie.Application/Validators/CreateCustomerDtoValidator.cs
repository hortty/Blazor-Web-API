using FluentValidation;
using Movie.Domain.Dtos.CustomerDto;
using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Validators
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(model => model.Phone).NotEmpty().WithMessage("Phone não pode estar vazio");
            RuleFor(model => model.Address).NotEmpty().WithMessage("Address não pode estar vazio.");
            RuleFor(modelo => modelo.Age).GreaterThan(0).WithMessage("Age deve ser maior que zero");
            RuleFor(modelo => modelo.Name).NotEmpty().WithMessage("Name não pode estar vazio");

            RuleFor(modelo => modelo.Login).NotEmpty().WithMessage("Login não pode estar vazio");
            RuleFor(modelo => modelo.Email).NotEmpty().WithMessage("Email não pode estar vazio");
            RuleFor(modelo => modelo.Password).NotEmpty().WithMessage("Senha não pode estar vazio");
        }
    }
}
