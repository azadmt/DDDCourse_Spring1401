using Framework.Core;
using Framework.Core.Domian;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Framework.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IBus eventBus;

        public ApplicationDbContext(DbContextOptions options, IBus eventBus)
      : base(options)
        {
            this.eventBus = eventBus;
        }
        public DbSet<OutBoxMessage> OutBoxMessages { get; set; }

        public override int SaveChanges()
        {
            var aggregates = ChangeTracker.Entries<AggregateRoot<Guid>>();
            List<IEvent> eventsToPublish = new List<IEvent>();
            foreach (var aggregate in aggregates)
            {
                eventsToPublish.AddRange(aggregate.Entity.Changes);
            }

            // Implement OutBox Pattern for Integration Events
            foreach (var @event in eventsToPublish)
            {
                eventBus.Publish((dynamic)@event);

                if (@event is IntegrationEvent)
                {
                    OutBoxMessages.Add(new OutBoxMessage
                    {
                        Id = Guid.NewGuid(),
                        Content = JsonConvert.SerializeObject(@event),

                        IsSynced = false
                    });
                }

            }
            return base.SaveChanges();
        }
    }
}
