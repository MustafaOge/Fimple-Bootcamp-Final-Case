using AutoMapper;
using BankingApp.Core.Entities;
using BankingApp.Core.Repositories;
using BankingApp.Core.Resources;
using BankingApp.Core.Services;
using BankingApp.Core.UnitOfWorks;
using BankingApp.Repository.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Service.Services
{
    public class TransferService : ITransferService
    {
        private readonly ITransferRepository _repository;
        private readonly IAccountRepository _accountRepository;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public TransferService(IUnitOfWork unitOfWork, ITransferRepository repository, IMapper mapper, IAccountRepository accountRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
            _mapper = mapper;
            _accountRepository = accountRepository;


        }


        public async Task<TransferResource> Transfer(TransferResource resource, CancellationToken cancellationToken)
        {
            if (_accountRepository == null)
            {
                Console.WriteLine("_accountRepository null. Dependency injection issue?");
                return null;
            }
            try
            {


                // Gönderen hesaptan çıkarma işlemi
                var senderAccount = await _accountRepository.GetByIdAsync(resource.SenderAccount);
                if (senderAccount == null)
                {
                    Console.WriteLine("Gönderen hesap bulunamadı.");
                    return null;
                }

                if (senderAccount.Balance < resource.Amount)
                {
                    Console.WriteLine("Gönderen hesapta yeterli bakiye bulunmamaktadır.");
                    return null;
                }

                senderAccount.Balance -= resource.Amount;

                // Alıcı hesaba ekleme işlemi
                var receiverAccount = await _accountRepository.GetByIdAsync(resource.ReceiverAccount);
                if (receiverAccount == null)
                {
                    Console.WriteLine("Alıcı hesap bulunamadı.");
                    return null;
                }

                receiverAccount.Balance += resource.Amount;

                // Transfer işlemi gerçekleştirilecekse:
                var transferEntity = _mapper.Map<TransferResource, Transfer>(resource);
                _repository.AddAsync(transferEntity);

                // Gerçekleştirilen transfer işlemini logla
                Console.WriteLine($"Transfer başarıyla gerçekleştirildi. Gönderen hesap: {resource.SenderAccount}, Alıcı hesap: {resource.ReceiverAccount}, Miktar: {resource.Amount}");

                await _unitOfWork.CommitChangesAsync();

                return resource;
            }
            catch (Exception ex)
            {
                // Hata durumunda logla
                Console.WriteLine($"Transfer işlemi sırasında bir hata oluştur: {ex.Message}");
                return null;
            }
        }
    }
}


