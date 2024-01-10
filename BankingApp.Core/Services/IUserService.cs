using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Core.DTOs.User;
using BankingApp.Core.Resources;

namespace BankingApp.Core.Services
{
    /// <summary>
    /// Interface defining user-related services.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Asynchronously retrieves detailed information for a specific user based on their ID.
        /// </summary>
        /// <param name="id">ID of the user to retrieve.</param>
        Task<UserDto> GetByIdAsync(int id);

        /// <summary>
        /// Asynchronously retrieves a list of all users.
        /// </summary>
        Task<IEnumerable<UserListDto>> GetAllAsync();

        /// <summary>
        /// Asynchronously creates a new user based on the provided data transfer object (DTO).
        /// </summary>
        /// <param name="entity">Data transfer object containing information for creating a new user.</param>
        Task<UserDto> CreateAsync(UserCreateDto entity);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task UpdateAsync(int id, UserUpdateDto entity);

        /// <summary>
        /// Asynchronously removes a user based on their ID.
        /// </summary>
        /// <param name="id">ID of the user to remove.</param>
        Task RemoveAsync(int id);

        /// <summary>
        /// Gets the statistics for a specific user, including information about their pets.
        /// </summary>
        /// <param name="id">The unique identifier of the user.</param>
        /// <returns>A task that represents the asynchronous operation and contains the user statistics DTO.</returns>
        /// 

        ///
        Task<UserResource> Register(RegisterResource resource, CancellationToken cancellationToken);
        Task<UserResource> Login(LoginResource resource, CancellationToken cancellationToken);

    }


}
