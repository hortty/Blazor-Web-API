using FluentValidation;
using Movie.Domain.Dtos.ShoppingCartMovieDto;
using Movie.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Validators
{
    public class UpdateShoppingCartMovieDtoValidator : AbstractValidator<UpdateShoppingCartMovieDto>
    {
        public UpdateShoppingCartMovieDtoValidator()
        {
            RuleFor(model => model.Id).NotNull().WithMessage("Id não pode ser nulo.");
            RuleFor(model => model.FilmId).NotNull().WithMessage("FilmId não pode ser nulo.");
            RuleFor(model => model.ShoppingCartId).NotNull().WithMessage("ShoppingCartId não pode ser nulo.");
            RuleFor(modelo => modelo.Name).NotEmpty().WithMessage("Name não pode estar vazio");
            RuleFor(modelo => modelo.Amount).GreaterThan(0).WithMessage("Amount deve ser maior que zero");
            RuleFor(modelo => modelo.Price).GreaterThan(0).WithMessage("Price deve ser maior que zero");
        }
    }
}
