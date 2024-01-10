
using BankingApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.DTOs.User
{
    public class UserUpdateDto : BaseModelDto
    {
        public List<string> Roles { get; set; }

        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }



    }
}
