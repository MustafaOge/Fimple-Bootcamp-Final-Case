using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Entities;

namespace BankingApp.Core.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        /// <summary>
        /// Asynchronously retrieves an entity with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the entity.</param>
        /// <returns>The entity with the specified ID.</returns>
        Task<User> GetByIdWithOwnershipsAsync(int id);

        /// <summary>
        /// Gets a user by its ID with all related entities and their sub-relations.
        /// </summary>
        /// <param name="id">The ID of the user.</param>
        /// <returns>A <see cref="Task{TResult}"/> representing the asynchronous operation, containing the user with all related entities and sub-relations.</returns>
        Task<User> GetByIdWithRelationsAndSubRelations(int id);

    }
}
