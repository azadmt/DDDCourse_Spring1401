using Framework.Core;
using System;
using System.Collections.Generic;

namespace AccountManagement.Domain.BankAccount
{
    public class AccountNumber: ValueObject
    {
        public string Value { get; private set; }

        public AccountNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException();

            Value = value;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
