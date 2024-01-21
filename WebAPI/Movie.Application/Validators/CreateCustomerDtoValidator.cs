using FluentValidation;
using Movie.Domain.Dtos;
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
            RuleFor(model => model.UserId).NotNull().WithMessage("UserId não pode ser nulo.");
            RuleFor(model => model.Phone).NotEmpty().WithMessage("Phone não pode estar vazio");
            RuleFor(model => model.Address).NotEmpty().WithMessage("Address não pode estar vazio.");
            RuleFor(modelo => modelo.Age).GreaterThan(0).WithMessage("Age deve ser maior que zero");
            RuleFor(modelo => modelo.UserId).NotEmpty().WithMessage("UserId deve ser preenchido");
            RuleFor(modelo => modelo.Name).NotEmpty().WithMessage("Name não pode estar vazio");
        }
    }
}
