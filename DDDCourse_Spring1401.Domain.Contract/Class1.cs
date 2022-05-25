using Framework.Core;
using System;

namespace DDDCourse_Spring1401.Domain.Contract
{
    public class AccountCratedEvent : IEvent
    {

        public AccountCratedEvent(Guid id, Guid ownerId, decimal balance, int accountType, string accountNumber)
        {
            Id = id;
            OwnerId = ownerId;
            Balance = balance;
            AccountType = accountType;
            AccountNumber = accountNumber;
        }

        public Guid Id { get; }
        public Guid OwnerId { get; }
        public decimal Balance { get; }
        public int AccountType { get; }
        public string AccountNumber { get; }
    }
}
