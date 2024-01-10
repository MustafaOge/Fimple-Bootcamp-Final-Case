using BankingApp.Core.DTOs.User;
using BankingApp.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using BankingApp.Repository.Context;
using BankingApp.Core.Services;
using BankingApp.Core.Resources;
using Microsoft.EntityFrameworkCore;
using BankingApp.Service.Services;


namespace BankingApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITransferService _transferService;
        private readonly BankingAppDbContext _context;
        public UsersController(IUserService userService, BankingAppDbContext context, ITransferService transferService)
        {
            _userService = userService;
            _context = context;
            _transferService = transferService;
        }

      
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterResource resource, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _userService.Register(resource, cancellationToken);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource resource, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _userService.Login(resource, cancellationToken);
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(new { ErrorMessage = e.Message });
            }
        }
        [HttpGet("{userId}")]   
        public IActionResult GetUserWithAccounts(Guid userId)
        {
            var userWithAccounts = _context.Users
                .Where(u => u.Id == userId)
                .Select(u => new
                {
                    Name = u.Name,
                    Surname = u.Surname,
                    IdentityNumber = u.IdentityNumber,
                    Accounts = u.Accounts.Select(a => new
                    {
                        Balance = a.Balance,
                        Currency = a.Currency,
                        
                    }).ToList()
                })
                .FirstOrDefault();

            if (userWithAccounts == null)
            {
                return NotFound("Kullanıcı bulunamadı");
            }

            return Ok(userWithAccounts);
        }

        [HttpPost("PerformTransfer")]
        public async Task<IActionResult> PerformTransfer([FromBody] TransferResource transferResource, CancellationToken cancellationToken)
        {
            try
            {
                // Transfer işlemini gerçekleştir
                var result = await _transferService.Transfer(transferResource, cancellationToken);

                if (result != null)
                {
                    return Ok(new { Message = "Transfer işlemi başarıyla gerçekleştirildi.", TransferDetails = result });
                }
                else
                {
                    return BadRequest(new { ErrorMessage = "Transfer işlemi başarısız oldu." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { ErrorMessage = $"Transfer işlemi sırasında bir hata oluştu: {ex.Message}" });
            }
        }




    }
}
