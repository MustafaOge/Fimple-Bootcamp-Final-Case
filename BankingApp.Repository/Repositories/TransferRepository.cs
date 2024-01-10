using BankingApp.Core.Entities;
using BankingApp.Core.Repositories;
using BankingApp.Entities;
using BankingApp.Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VirtualPetCare.Repository.Repositories;

namespace BankingApp.Repository.Repositories
{
    public class TransferRepository : GenericRepository<Transfer>, ITransferRepository
    {
        public TransferRepository(BankingAppDbContext context) : base(context)
        {
        }

        public Task<Transfer> GetByIdWithOwnershipsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Transfer> GetByIdWithRelationsAndSubRelations(int id)
        {
            throw new NotImplementedException();
        }
    }
}
