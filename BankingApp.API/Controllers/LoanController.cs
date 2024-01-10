using AutoMapper;
using BankingApp.Core.DTOs.Credit;
using BankingApp.Core.Entities.credit;
using BankingApp.Core.Entities.Loan;
using BankingApp.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _loanService;
        private readonly IMapper _mapper;


        public LoanController(ILoanService loanService, IMapper mapper)
        {
            _loanService = loanService;
            _mapper = mapper;
        }

        [HttpPost("Apply")]
        public IActionResult ApplyForLoan([FromBody] LoanApplicationDTO loanDTO)
        {
            try
            {
                var loanApplication = _mapper.Map<LoanApplication>(loanDTO);


                var loanDetails = _loanService.ApproveLoanApplication(loanApplication);

                return Ok(new { Message = "Loan application approved.", LoanDetails = loanDetails });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = $"An error occurred during the loan application: {ex.Message}" });
            }
        }

        [HttpGet("{userId}/Payments")]
        public IActionResult GetLoanPayments(Guid userId)
        {
            try
            {
                var loanPayments = _loanService.TrackLoanPayments(userId);

                return Ok(new { LoanPayments = loanPayments });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = $"An error occurred while fetching loan payments: {ex.Message}" });
            }
        }
    }

}
