using CustomerManagement.Domain;
using Microsoft.AspNetCore.Mvc;
using ReadModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReadModel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly ReadModelDbContext readModelDbContext;

        public AccountController(ReadModelDbContext readModelDbContext)
        {
            this.readModelDbContext = readModelDbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
        
            return Ok(readModelDbContext.Set<Customer>().ToList());
        }
    }
}
