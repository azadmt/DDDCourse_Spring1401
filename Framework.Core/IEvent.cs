using System;

namespace Framework.Core
{
    public interface IEvent { }

    public interface IntegrationEvent : IEvent
    {
        Guid EventId { get; set; }
    }


}
