﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Core.DTOs.User;

namespace VirtualPetCare.Core.Validations.User
{
    public class UserUpdateValidator : AbstractValidator<UserUpdateDto>
    {
        public UserUpdateValidator()
        {
            RuleFor(x=>x.PasswordSalt).MaximumLength(30);
        }
    }
}
