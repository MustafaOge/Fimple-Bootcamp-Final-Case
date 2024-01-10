using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Core.DTOs.User;

namespace BankingApp.Core.DTOs.Account
{
    public class AccountCreateDto
    {
        public Decimal Balance { get; set; }
        public string Currency { get; set; }


        public Guid UserId { get; set; }

        //public virtual UserCreateDto User { get; set; }

    }
}
