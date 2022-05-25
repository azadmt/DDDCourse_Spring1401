using Autofac;
using Framework.Core;
using System.Collections.Generic;

namespace Framework.Bus.Autofac
{
    public class AutofacBus : IBus
    {
        private readonly IComponentContext services;

        public AutofacBus(IComponentContext container)
        {
            this.services = container;
        }
        public void Send<TCommand>(TCommand command)
        {
            var commandHandler = services.Resolve<ICommandHandler<TCommand>>();
            var decoratedCommandHandler = new CommandHandlerLoggerDecorator<TCommand>(commandHandler);
            decoratedCommandHandler.Handle(command);
        }


        public void Publish<TEvent>(TEvent @event)
        {
            var eventHandlers = services.Resolve<IEnumerable<IEventHandler<TEvent>>>();

            foreach (var eventHandler in eventHandlers)
            {
                eventHandler.Handle(@event);

            }
        }

        public void SubScribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            //  inlineSubscribers.Add(eventHandler);
        }
    }
}
