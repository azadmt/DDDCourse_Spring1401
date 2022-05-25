using Framework.Core;
using System;
using System.Collections.Generic;

namespace AccountManagement.Domain.BankAccount
{
    public class Money : ValueObject
    {
        public Money(decimal amount)
        {
            if (amount <= 0)
            {
                //TODO : Use DomainException
                throw new Exception("argument can not be less than zero!!!"); 
            }

            Amount = amount;
        }
        public decimal Amount { get; private set; }

        public static Money operator -(Money a, Money b)
        {
            return new Money(a.Amount - b.Amount);
        }

        public static Money operator +(Money a, Money b)
        {
            return new Money(a.Amount + b.Amount);
        }

        public static bool operator >(Money a, Money b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Amount > b.Amount;
        }

        public static bool operator <(Money a, Money b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Amount < b.Amount;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Amount;
        }
    }
}
