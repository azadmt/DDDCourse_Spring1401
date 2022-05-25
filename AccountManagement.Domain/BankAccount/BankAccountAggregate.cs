using AccountManagement.Domain.Contract;
using Framework.Core;
using System;
using System.Collections.Generic;

namespace AccountManagement.Domain.BankAccount
{
    public class BankAccountAggregate : Entity<Guid>
    {
        public List<IEvent> Changes { get; private set; } = new List<IEvent>();
        private BankAccountAggregate() { }

        private BankAccountAggregate(Guid id,
            Guid ownerId,
            AccountNumber accountNumber,
            AccountType accountType)
        {
            Id = id;
            OwnerId = ownerId;
            Number = accountNumber;
            Type = accountType;

            Changes.Add(new AccountCratedEvent(Id, ownerId, 0, (int)Type, Number.Value));
        }

        /// <summary>
        /// Factory
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="ownerId"></param>
        /// <param name="accountNumber"></param>
        /// <param name="accountType"></param>
        /// <returns></returns>
        public static BankAccountAggregate Create(
            Guid id,
            Guid ownerId,
            AccountNumber accountNumber,
            AccountType accountType)
        {
            var bankAccount = new BankAccountAggregate(id, ownerId, accountNumber, accountType);
            return bankAccount;
        }

        public static BankAccountAggregate CreateWithInitialBalance(
            Guid id,
            Guid ownerId,
            AccountNumber accountNumber,
            AccountType accountType,
            Money initialBalance)
        {
            var bankAccount = new BankAccountAggregate(id, ownerId, accountNumber, accountType);
            bankAccount.Deposit(initialBalance);
            return bankAccount;
        }

        public Guid OwnerId { get; private set; }
        public AccountNumber Number { get; private set; }

        //   private Money _balance;
        public Money Balance { get; private set; }

        public AccountType Type { get; private set; }

        public void Withraw(Money amount)
        {
            if (Balance < amount)
                throw new AccountBalanceCanNotBeNegativeException();

            Balance -= amount;
         
        }

        public void Deposit(Money amount)
        {
            Balance += amount;
            Changes.Add(new AccountDeposited(Id, Balance.Amount));
        }
    }
}
