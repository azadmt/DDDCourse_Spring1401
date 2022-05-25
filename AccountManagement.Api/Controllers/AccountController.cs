using AccountManagement.Application.Contract;
using AccountManagement.Domain.BankAccount;
using AccountManagement.Domain.Contract;
using AccountManagement.Persistence.EF;
using Framework.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        private readonly IBus bus;

        public AccountController(IBus bus, AccountManagementDbContext accountManagementDbContext, IBankAccountRepository bankAccountRepository)
        {
            this.bus = bus;
        }

        [HttpPost]
        public IActionResult Post(OpenNewAccountCommand openNewAccountDto)
        {

            bus.Send(openNewAccountDto);
            return Ok();
        }

        [HttpPost("Withraw")]
        public IActionResult Post(WithdrawFromAccountCommand dto)
        {
            bus.Send(dto);

            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(null);
        }
    }
}
