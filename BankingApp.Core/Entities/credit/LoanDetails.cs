using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Entities.credit
{
    public class LoanDetails
    {
        public Guid UserId { get; set; }

        public decimal InterestRate { get; set; }
        public decimal LoanAmount { get; set; }
        public decimal MonthlyPayment { get; set; }
        public int LoanTermMonths { get; set; }
    }
}
