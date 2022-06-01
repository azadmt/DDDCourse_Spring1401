using Framework.Core;
using System;

namespace AccountManagement.Domain.Contract
{
    public class AccountCratedEvent : IntegrationEvent
    {
        public AccountCratedEvent(Guid id, Guid ownerId, decimal balance, string accountType, string accountNumber)
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
        public string AccountType { get; }
        public string AccountNumber { get; }
        public Guid EventId { get; set; } = Guid.NewGuid();
    }
}
