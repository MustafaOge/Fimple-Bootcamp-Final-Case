using AutoMapper;
using BankingApp.Core.DTOs.User;
using BankingApp.Core.Entities;
using BankingApp.Core.Repositories;
using BankingApp.Core.Resources;
using BankingApp.Core.Services;
using BankingApp.Core.UnitOfWorks;
using BankingApp.Entities;
using BankingApp.Repository.Context;
using BankingApp.Service.Exceptions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankingApp.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly BankingAppDbContext _context;
        private readonly string _pepper;
        private readonly int _iteration = 3;

        public UserService(IUnitOfWork unitOfWork, IUserRepository repository, IMapper mapper, BankingAppDbContext context)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _context = context;
            _pepper = Environment.GetEnvironmentVariable("FimpleBootcampFinalProject");

        }

        public Task<UserDto> CreateAsync(UserCreateDto entity)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<UserListDto>> GetAllAsync()
        {
            var users = await _repository.GetAll().ToListAsync();

            if (!users.Any())
                throw new NotFoundException("Users not found.");

            var userDtos = _mapper.Map<List<UserListDto>>(users);

            return userDtos;
        }

        /// <inheritdoc/>
        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdWithOwnershipsAsync(id);

            if (user == null)
                throw new NotFoundException($"User({id}) not found.");

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(int id, UserUpdateDto entity)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
                throw new NotFoundException($"User({id}) not found.");

            user.PasswordSalt = entity.PasswordSalt != default ? entity.PasswordSalt : user.PasswordSalt;
            user.Roles = entity.Roles != default ? entity.Roles : user.Roles;
            user.UpdatedAt = DateTime.UtcNow;

            await _unitOfWork.CommitChangesAsync();
        }

        [HttpGet("{userId}")]
        public async Task<UserResource> ListAccount(UserResource userReosurce, CancellationToken cancellationToken, Guid userId)
        {
            var userWithAccounts = _context.Users
                .Include(u => u.Accounts)
                .FirstOrDefault(u => u.Id == userId);

            //if (userWithAccounts == null)
            //{
            //    return ("Kullanıcı bulunamadı");
            //}

            return new UserResource(userWithAccounts.Name, userWithAccounts.Surname, userWithAccounts.IdentityNumber, userWithAccounts.Accounts);
        }


        public async Task<UserResource> Register(RegisterResource resource, CancellationToken cancellationToken)
        {
            var user = new User
            {
                Name = resource.Name,
                Surname = resource.Surname,
                IdentityNumber = resource.IdentityNumber,

                PasswordSalt = PasswordHasher.GenerateSalt()
            };
            user.PasswordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _pepper, _iteration);
            //await _context.Users.AddAsync(user, cancellationToken);

            await _repository.AddAsync(user);
            await _unitOfWork.CommitChangesAsync();

            return new UserResource(user.Name, user.Surname, user.IdentityNumber, user.Accounts);
        }

        public async Task<UserResource> Login(LoginResource resource, CancellationToken cancellationToken)
        {



            var user = await _context.Users
                .FirstOrDefaultAsync(x => x.IdentityNumber == resource.IdentityNumber, cancellationToken);

            if (user == null)
                throw new Exception("Identity Number or password did not match.");

            var passwordHash = PasswordHasher.ComputeHash(resource.Password, user.PasswordSalt, _pepper, _iteration);
            if (user.PasswordHash != passwordHash)
                throw new Exception("Identity Number or password did not match.");

            return new UserResource(user.Name, user.Surname, user.IdentityNumber, user.Accounts);
        }


    }

}