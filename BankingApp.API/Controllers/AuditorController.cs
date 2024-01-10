using AutoMapper;
using BankingApp.Core.DTOs.Account;
using BankingApp.Core.Entities;
using BankingApp.Entities;
using BankingApp.Repository.Context;
using Microsoft.AspNetCore.Mvc;

namespace BankingApp.API.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class AuditorController : ControllerBase
    {
        private readonly BankingAppDbContext _context;
        private readonly IMapper _mapper;
        public AuditorController(BankingAppDbContext context, IMapper mapper)
        {
           _context = context;
            _mapper = mapper;
            
        }

        [HttpPost("OpenAccount")]
        public async Task<ActionResult<AccountCreateDto>> OpenAccount(AccountCreateDto accountCreateDto)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == accountCreateDto.UserId);

            if (user != null)
            {

                var account = _mapper.Map<AccountCreateDto, Account>(accountCreateDto);

                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, account);
            }
            else
            {
                return BadRequest("No user found with the specified UserId.");
            }


        }
        public Guid UserId { get; set; }

        [HttpPut]


        [HttpGet]
        public async Task<ActionResult<Account>> GetAccount(int accountId)
        {
            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null)
            {
                return NotFound();
            }
            return account;

        }


    }
}
