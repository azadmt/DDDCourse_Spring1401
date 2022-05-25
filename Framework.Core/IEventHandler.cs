namespace Framework.Core
{
    public interface IEventHandler<TEvent> 
    {
        void Handle(TEvent @event);
    }
}
