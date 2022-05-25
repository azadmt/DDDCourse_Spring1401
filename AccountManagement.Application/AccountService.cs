//using AccountManagement.Application.Contract;
//using AccountManagement.Domain.BankAccount;
//using System;
//using System.Collections.Generic;

//namespace AccountManagement.Application
//{
//    public class AccountService : IAccountService
//    {
//        private readonly IBankAccountRepository accountRepository;
//        public AccountService(IBankAccountRepository accountRepository)
//        {
//            this.accountRepository = accountRepository;
//        }

//        public IList<BankAccountAggregate> GetAll()
//        {
//            return accountRepository.GetAll();
//        }

//        public void OpenNewAccount(OpenNewAccountDto openNewAccountDto)
//        {

//            //generate identity 
//            var account = BankAccountAggregate.Create(
//                Guid.NewGuid(),
//                openNewAccountDto.OwnerId,
//                new AccountNumber(openNewAccountDto.Number),
//                AccountType.Current
//                );

//            accountRepository.Add(account);
//            //publish AccountCreated Event
//        }

//        public void Withdraw(WithdrawFromAccountDto withdrawFromAccountDto)
//        {
//            var account = accountRepository.Get(withdrawFromAccountDto.AccountId);
//            account.Withraw(new Money(withdrawFromAccountDto.Amount));
//            accountRepository.Update(account);
//        }
//    }
//}





