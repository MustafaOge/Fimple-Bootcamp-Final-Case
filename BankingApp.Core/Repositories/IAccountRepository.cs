using BankingApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Repositories
{
    public interface IAccountRepository 
    {
        Task<Account> GetByIdAsync(Guid accountId);
        Task<IEnumerable<Account>> GetAllAsync();
        Task CreateAsync(Account account);
        Task UpdateAsync(Account account);


    }
}
