using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Core.DTOs.User;

namespace BankingApp.Service.Validations.User
{
    public class UserUpdateDtoValidation : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateDtoValidation()
        {
            RuleFor(x => x.PasswordSalt).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");
            RuleFor(x => x.Roles).NotNull().NotEmpty().WithMessage("{PropertyName} is required!");
        }
    }
}
