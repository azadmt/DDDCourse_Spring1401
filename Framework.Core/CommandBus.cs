using Autofac;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public class Bus : IBus
    {
        private readonly IComponentContext services;

        public Bus(IComponentContext container)
        {
            this.services = container;
          //  this.services = services.BuildServiceProvider();
        }
        public void Send<TCommand>(TCommand command)
        {

            var commandHandler =services.Resolve<ICommandHandler<TCommand>>();
            commandHandler.Handle(command);
        }


        public void Publish<TEvent>(TEvent @event)
        {
            var eventHandlers = services.Resolve<IEventHandler<TEvent>>();

            //foreach (var eventHandler in eventHandlers)
            //{
                eventHandlers.Handle(@event);

           // }
        }

        public void SubScribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
          //  inlineSubscribers.Add(eventHandler);
        }
    }
}
