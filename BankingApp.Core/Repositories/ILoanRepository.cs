using BankingApp.Core.Entities.credit;
using BankingApp.Core.Entities.Loan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Repositories
{
    public interface ILoanRepository
    {
        LoanDetails GetLoanDetails(Guid userId);
        IEnumerable<LoanPayment> GetLoanPayments(Guid userId);
        void SaveLoanApplication(LoanApplication loanApplication);
    }
}
