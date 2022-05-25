using AccountManagement.Domain.Contract;
using Framework.Core;
using System;

namespace AccountManagement.EventHandlers
{
    public class AccountCeatedEventHandler : IEventHandler<AccountCratedEvent>
    {
        private readonly IBus commandBus;

        public AccountCeatedEventHandler(IBus commandBus)
        {
            this.commandBus = commandBus;
        }
        public void Handle(AccountCratedEvent @event)
        {
          //  throw new NotImplementedException();
        }
    }
}
