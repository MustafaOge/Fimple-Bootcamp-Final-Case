using BankingApp.Core.Entities.credit;
using BankingApp.Core.Entities.Loan;
using BankingApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Repository.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly List<LoanApplication> _loanApplications;
        private readonly List<LoanDetails> _loanDetails;
        private readonly List<LoanPayment> _loanPayments;

        public LoanRepository()
        {
            _loanApplications = new List<LoanApplication>();
            _loanDetails = new List<LoanDetails>();
            _loanPayments = new List<LoanPayment>();
        }

        public LoanDetails GetLoanDetails(Guid userId)
        {
            return _loanDetails.FirstOrDefault(ld => ld.UserId == userId);
        }

        public IEnumerable<LoanPayment> GetLoanPayments(Guid userId)
        {
            return _loanPayments.Where(lp => lp.UserId == userId);
        }

        public void SaveLoanApplication(LoanApplication loanApplication)
        {
            _loanApplications.Add(loanApplication);
        }
    }
}
