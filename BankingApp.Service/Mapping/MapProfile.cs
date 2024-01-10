using AutoMapper;
using BankingApp.Core.DTOs.User;
using BankingApp.Core.DTOs.Account;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankingApp.Entities;
using BankingApp.Core.Entities;
using BankingApp.Core.Entities.Loan;
using BankingApp.Core.DTOs.Credit;


namespace BankingApp.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //User
            CreateMap<User, UserDto>();
            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<UserCreateDto, User>().ReverseMap();

          

            //Account
            CreateMap<Account, AccountDto>();
            CreateMap<AccountCreateDto, Account>().ReverseMap();

            CreateMap<LoanApplicationDTO, LoanApplication>();

        }


    }
}
