namespace Framework.Core
{
    public interface IEventBus
    {
        void Publish<TEvent>(TEvent command);
        void SubScribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;
    }
}
