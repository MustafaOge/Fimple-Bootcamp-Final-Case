using BankingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Resources
{
    public sealed record RegisterResource(string Name, string Surname, string IdentityNumber, string Password);


}

