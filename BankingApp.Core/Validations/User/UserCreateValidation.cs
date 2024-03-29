﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Core.DTOs.User;

namespace VirtualPetCare.Core.Validations.User
{
    public class UserCreateValidation : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidation()
        {
            RuleFor(x=>x.Name).NotNull().NotEmpty().WithMessage("{PropertyName} is required!").MaximumLength(30);
        }
    }
}
