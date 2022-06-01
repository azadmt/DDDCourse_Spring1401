using CustomerManagement.DAL;
using CustomerManagement.Domain;
using CustomerManagement.Domain.Contract;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagement.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly CustomerManagementDbContext customerManagementDbContext;
        private readonly IBus bus;

        public CustomerController(CustomerManagementDbContext customerManagementDbContext, IBus bus)
        {
            this.customerManagementDbContext = customerManagementDbContext;
            this.bus = bus;
        }


        [HttpPost]
        public async Task<IActionResult> CreateCustomer(Customer model)
        {
            // Validate model!!!
            await customerManagementDbContext.Set<Customer>().AddAsync(model);
            await customerManagementDbContext.SaveChangesAsync();
            await bus.Publish(new CustomerCreatedEvent(model.Id, model.FirstName, model.LastName, model.NationalCode, model.BirthDate));
            return Ok();
        }
    }
}
