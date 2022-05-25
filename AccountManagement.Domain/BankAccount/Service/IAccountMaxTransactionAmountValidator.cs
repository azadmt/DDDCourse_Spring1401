using System;

namespace AccountManagement.Domain.BankAccount
{
    public interface IAccountMaxTransactionAmountValidator
    {
        void Validate(Guid id,decimal amount);
    }
}
