﻿using BankingApp.Core.DTOs.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.DTOs.User
{
    public class UserCreateDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdentityNumber { get; set; }
        public Guid UserId { get; set; }

        public virtual ICollection<AccountDto> Accounts { get; set; }

        public string PasswordSalt { get; set; }
        public List<string> Roles { get; set; }

    }
}

