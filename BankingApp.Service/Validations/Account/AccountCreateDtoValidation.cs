using BankingApp.Core.DTOs.Account;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Service.Validations.Account
{
    public class AccountCreateDtoValidation : AbstractValidator<AccountCreateDto>
    {
        public AccountCreateDtoValidation()
        {
            RuleFor(x => x.Balance).GreaterThan(500).WithMessage("Minimum account opening balance must be 500 ");
        }
    }
}
