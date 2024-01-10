using BankingApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Entities
{
    public class Account : BaseEntity
    {
        
        public Decimal Balance { get; set; }
        public string Currency {  get; set; }
        public Guid UserId { get; set; }

    }
}
