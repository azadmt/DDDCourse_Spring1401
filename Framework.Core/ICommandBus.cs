namespace Framework.Core
{
    public interface ICommandBus
    {
        void Send<TCommand>(TCommand command);
    }

    public interface IBus : ICommandBus, IEventBus
    {

    }
}
