using Newtonsoft.Json;
using System;
using System.Diagnostics;

namespace Framework.Core
{
    public interface ICommandHandler<TCommand>
    {
        void Handle(TCommand command);
    }

    public class CommandHandlerLoggerDecorator<TCommand> : ICommandHandler<TCommand>
    {
        private readonly ICommandHandler<TCommand> commandHandler;

        public CommandHandlerLoggerDecorator(ICommandHandler<TCommand> commandHandler)
        {
            this.commandHandler = commandHandler;
        }
        public void Handle(TCommand command)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine($"start at {DateTime.Now} with {Environment.UserName} - {JsonConvert.SerializeObject(command)}");
            sw.Start();
            commandHandler.Handle(command);
            sw.Stop();
            Console.WriteLine($"End ;{sw.ElapsedMilliseconds}");

        }
    }
}
