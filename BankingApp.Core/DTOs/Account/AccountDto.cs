using BankingApp.Core.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.DTOs.Account
{
    public class AccountDto
    {
        public Decimal Balance { get; set; }
        public string Currency { get; set; }
        public Guid UserId { get; set; }
        public virtual UserCreateDto User { get; set; }
    }
}
