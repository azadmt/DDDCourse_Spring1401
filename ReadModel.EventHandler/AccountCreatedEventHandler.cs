using AccountManagement.Domain.Contract;
using MassTransit;
using System;
using System.Threading.Tasks;

namespace ReadModel.EventHandler
{
    public class AccountCreatedEventHandler : IConsumer<AccountCratedEvent>
    {
        public Task Consume(ConsumeContext<AccountCratedEvent> context)
        {
            var data = context.Message;
            return Task.CompletedTask;
        }
    }
}
