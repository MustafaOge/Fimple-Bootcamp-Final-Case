using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Core.Repositories;
using BankingApp.Repository.Context;
using BankingApp.Entities;

namespace VirtualPetCare.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BankingAppDbContext context) : base(context)
        {
        }

        public Task<User> GetByIdWithOwnershipsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdWithRelationsAndSubRelations(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<User> GetByIdWithRelationsAndSubRelations(int id)
        //{
        //    var user = await GetAll()
        //        .Include(x => x.Pets)
        //            .ThenInclude(x => x.Health)
        //        .Include(x => x.Pets)
        //            .ThenInclude(x => x.PetSpecies)
        //        .Include(x => x.Pets).ThenInclude(x => x.FoodHistories)
        //                .ThenInclude(x => x.Food)
        //        .Include(x => x.Pets)
        //        .ThenInclude(x => x.FoodHistories)
        //                .ThenInclude(x => x.Food)
        //        .Include(x => x.Pets)
        //        .ThenInclude(x => x.ActivityHistories)
        //                .ThenInclude(x => x.Activity)
        //         .Include(x => x.Pets)
        //         .ThenInclude(x => x.TrainingHistories)
        //                .ThenInclude(x => x.Training)
        //        .FirstOrDefaultAsync(X => X.Id == id);
        //    return user;
        //}

        //async Task<User> IUserRepository.GetByIdWithOwnershipsAsync(int id)
        //{
        //    var user = await _context.Users.Include(x => x.Name).ThenInclude(x=> x.nA).FirstOrDefaultAsync(x=> x.Id == id);

        //    return user;
        //}
    }
}
