using AccountManagement.Domain.BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AccountManagement.Persistence.EF
{
    public class BankAccountRepository : IBankAccountRepository
    {
        private readonly AccountManagementDbContext dbContext;

        public BankAccountRepository(AccountManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(BankAccountAggregate aggregate)
        {
            dbContext.Set<BankAccountAggregate>().Add(aggregate);
            dbContext.SaveChanges();
        }

        public BankAccountAggregate Get(Guid id)
        {
            return dbContext.Set<BankAccountAggregate>().SingleOrDefault();
        }

        public IList<BankAccountAggregate> GetAll()
        {
            return dbContext.Set<BankAccountAggregate>().ToList();
        }

        public void Update(BankAccountAggregate accountAggregate)
        {
            dbContext.Set<BankAccountAggregate>().Update(accountAggregate);
            dbContext.SaveChanges();
        }
    }
}
