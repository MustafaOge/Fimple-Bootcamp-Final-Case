using BankingApp.Core.Entities.credit;
using BankingApp.Core.Entities.Loan;
using BankingApp.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Service.Services
{
    public interface ILoanService
    {
        LoanDetails ApproveLoanApplication(LoanApplication loanApplication);
        IEnumerable<LoanPayment> TrackLoanPayments(Guid userId);
    }

    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {
            _loanRepository = loanRepository;
        }

        public LoanDetails ApproveLoanApplication(LoanApplication loanApplication)
        {
            // Loan approval logic goes here
            // ...

            var loanDetails = new LoanDetails
            {
                InterestRate = 0.08m, // Example interest rate
                LoanAmount = 10000m, // Example loan amount
                MonthlyPayment = 900m, // Example monthly payment
                LoanTermMonths = 12 // Example loan term in months
            };

            _loanRepository.SaveLoanApplication(loanApplication);
            return loanDetails;
        }

        public IEnumerable<LoanPayment> TrackLoanPayments(Guid userId)
        {
            return _loanRepository.GetLoanPayments(userId);
        }
    }

}
