using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.DTOs.Credit
{
    public class LoanApplicationDTO
    {
        public Guid UserId { get; set; }
        public decimal Income { get; set; }
        public decimal Assets { get; set; }
    }
}
