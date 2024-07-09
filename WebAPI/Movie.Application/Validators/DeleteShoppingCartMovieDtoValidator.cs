using FluentValidation;
using Movie.Domain.Dtos.ShoppingCartMovieDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie.Application.Validators
{
    public class DeleteShoppingCartMovieDtoValidator : AbstractValidator<DeleteShoppingCartMovieDto>
    {
        public DeleteShoppingCartMovieDtoValidator()
        {
            RuleFor(model => model.Id).NotNull().WithMessage("ShoppingCartMovie não pode ser nulo.");
        }
    }
}
