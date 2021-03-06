using AccountManagement.Domain.BankAccount;
using Framework.Core;
using Framework.Core.Domian;
using Framework.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AccountManagement.Persistence.EF
{
    public class AccountManagementDbContext : ApplicationDbContext
    {
     
        private readonly IEventBus eventBus;

        public AccountManagementDbContext(DbContextOptions<AccountManagementDbContext> options, IBus eventBus)
        : base(options,eventBus)
        {
            this.eventBus = eventBus;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountManagementDbContext).Assembly);
        }

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
            base.SaveChanges();

            var outbox = OutBoxMessages.ToList();

            return 1;
        }
    }


}
