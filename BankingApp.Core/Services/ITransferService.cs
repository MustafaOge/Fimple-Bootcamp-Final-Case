using BankingApp.Core.Entities;
using BankingApp.Core.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Core.Services
{
    public interface ITransferService 
    {
        public Task<Transfer> AddAsync(Transfer entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transfer>> AddRangeAsync(IEnumerable<Transfer> items)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AnyAsync(Expression<Func<Transfer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Transfer>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Transfer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRangeAsync(IEnumerable<Transfer> items)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Transfer entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Transfer> Where(Expression<Func<Transfer, bool>> expression)
        {
            throw new NotImplementedException();
        }

        Task<TransferResource> Transfer(TransferResource resource, CancellationToken cancellationToken);

    }
}
