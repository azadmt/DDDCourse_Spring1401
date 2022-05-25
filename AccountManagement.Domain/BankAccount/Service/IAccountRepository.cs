using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace AccountManagement.Domain.BankAccount
{
    public interface IBankAccountRepository
    {
        IList<BankAccountAggregate> GetAll();
        BankAccountAggregate Get(Guid id);
        void Add(BankAccountAggregate aggregate);
        void Update(BankAccountAggregate accountAggregate);
    }
}
