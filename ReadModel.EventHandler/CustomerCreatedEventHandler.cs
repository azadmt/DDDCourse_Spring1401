using CustomerManagement.Domain.Contract;
using MassTransit;
using ReadModel.DAL;
using System.Threading.Tasks;

namespace ReadModel.EventHandler
{
    public class CustomerCreatedEventHandler : IConsumer<CustomerCreatedEvent>
    {
        private readonly ReadModelDbContext readModelDbContext;

        public CustomerCreatedEventHandler(ReadModelDbContext readModelDbContext)
        {
            this.readModelDbContext = readModelDbContext;
        }
        public async Task Consume(ConsumeContext<CustomerCreatedEvent> context)
        {
            var customerEvent = context.Message;
           
            var customer = new DAL.DataModel.CustomerModel
            {
                Id = customerEvent.Id,
                FirstName=customerEvent.FirstName,
                LastName=customerEvent.LastName,
                NationalCode=customerEvent.NationalCode,
                BirthDate=customerEvent.BirthDate
            };
            await readModelDbContext.Customers.AddAsync(customer);
            await readModelDbContext.SaveChangesAsync();            
        }
    }
}
