using System;

namespace AccountManagement.Application.Contract
{
    public class WithdrawFromAccountCommand
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; set; }

    }
}
