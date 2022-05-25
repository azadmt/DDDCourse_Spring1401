using AccountManagement.Application.Contract;
using AccountManagement.Domain.BankAccount;
using AccountManagement.Domain.Contract;
using AccountManagement.Persistence.EF;
using Framework.Core;
using MassTransit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IBusControl busControl;
        private readonly Framework.Core.IBus bus;
        private readonly AccountManagementDbContext accountManagementDbContext;
        private readonly IBankAccountRepository bankAccountRepository;

        public AccountController(IBusControl busControl,Framework.Core.IBus bus, AccountManagementDbContext accountManagementDbContext, IBankAccountRepository bankAccountRepository)
        {
            this.busControl = busControl;
            this.bus = bus;
            this.accountManagementDbContext = accountManagementDbContext;
            this.bankAccountRepository = bankAccountRepository;
        }

        [HttpPost]
        [HasPermission]
        public IActionResult Post(OpenNewAccountCommand openNewAccountDto)
        {
            busControl.Publish(new AccountCratedEvent(Guid.NewGuid(),Guid.NewGuid(),1500,0,"556644")).Wait();
            //if(UserHasPermission("OpenNewAccountCommand"))
            bus.Send(openNewAccountDto);
            return Ok();
        }

        [HttpPost("Withraw")]
        [HasPermission]
        public IActionResult Post(WithdrawFromAccountCommand dto)
        {
            
            //if(UserHasPermission("WithdrawFromAccountCommand"))
            bus.Send(dto);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(null);
        }
    }


    public class HasPermissionAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Do something before the action executes.
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Do something after the action executes.
        }
    }
}
