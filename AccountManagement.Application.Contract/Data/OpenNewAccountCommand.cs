using System;

namespace AccountManagement.Application.Contract
{
    public class OpenNewAccountCommand
    {
        public Guid OwnerId { get; set; }
        public decimal Amount { get; set; }
        public string Number { get; set; }
    }
}
