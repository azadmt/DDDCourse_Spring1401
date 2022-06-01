using AccountManagement.Domain.Contract;
using MassTransit;
using ReadModel.DAL;
using ReadModel.DAL.DataModel;
using System;
using System.Threading.Tasks;

namespace ReadModel.EventHandler
{
    public class AccountCreatedEventHandler : IConsumer<AccountCratedEvent>
    {
        private readonly ReadModelDbContext readModelDbContext;

        public AccountCreatedEventHandler(ReadModelDbContext readModelDbContext)
        {
            this.readModelDbContext = readModelDbContext;
        }
        public async Task Consume(ConsumeContext<AccountCratedEvent> context)
        {
            var accountEvent = context.Message;
            //inbox pattern : checked  is Handled before   accountEvent.EventId
            var accountModel = new AccountModel
            {
                Id = accountEvent.Id,
                Balance = accountEvent.Balance,
                Number = accountEvent.AccountNumber,
                OwnerId = accountEvent.OwnerId,
                Type = accountEvent.AccountType
            };
            var customer = await readModelDbContext.Customers.FindAsync(accountEvent.OwnerId);
            accountModel.OwnerName = $"{customer.FirstName} {customer.LastName} ({customer.NationalCode})";
            await readModelDbContext.Accounts.AddAsync(accountModel);
            //inbox pattern : add  accountEvent.EventId to Handled Event
            await readModelDbContext.SaveChangesAsync();
         
        }
    }
}
