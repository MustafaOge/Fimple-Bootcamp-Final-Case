using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Core.DTOs.User;

namespace BankingApp.Service.Validations.User
{
    public class UserCreatDtoValidation : AbstractValidator<UserCreateDto>
    {
        public UserCreatDtoValidation()
        {
            RuleFor(x=> x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Surname).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.PasswordSalt).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");

        }
    }
}

