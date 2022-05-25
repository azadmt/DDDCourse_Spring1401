using AccountManagement.Domain.BankAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Contract
{
    public interface IAccountService
    {
        IList<BankAccountAggregate> GetAll();
    }
}
