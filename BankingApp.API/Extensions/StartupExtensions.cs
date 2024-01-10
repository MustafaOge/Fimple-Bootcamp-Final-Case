using BankingApp.Core.Services;
using BankingApp.Core.UnitOfWorks;
using BankingApp.Repository.UnitOfWorks;
using BankingApp.Core.Repositories;

using VirtualPetCare.Repository.Repositories;
using VirtualPetCare.Service.Services;
using BankingApp.Service.Services;
using BankingApp.Repository.Repositories;

namespace BankingApp.API.Extensions
{
    public static class StartupExtensions
    {
        public static IServiceCollection AddScopedWithExtension(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<ITransferRepository, TransferRepository>();

            services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<ITransferService, TransferService>();

                 services.AddScoped<IAccountRepository, AccountRepository>();

            services.AddScoped<ILoanService, LoanService>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            return services;
        }
    }
}
