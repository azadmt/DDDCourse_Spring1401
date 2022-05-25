using Framework.Core;
using System;

namespace AccountManagement.Domain.Contract
{
    public class AccountDeposited : IEvent
    {
        public AccountDeposited(Guid id, decimal amount)
        {
            Id = id;
            Amount = amount;
        }

        public Guid Id { get; }
        public decimal Amount { get; }
    }
}
