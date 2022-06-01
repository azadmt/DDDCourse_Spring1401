using Framework.Core;
using System;

namespace CustomerManagement.Domain.Contract
{
    public class CustomerCreatedEvent
    {
        public CustomerCreatedEvent(Guid id, string firstName, string lastName, string nationalCode,
            DateTime birhtDate)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birhtDate;
            NationalCode = nationalCode;

        }
        public Guid Id { get; private set;}
        public string FirstName { get; private set;}
        public string LastName { get; private set;}
        public string NationalCode { get; private set;}
        public DateTime BirthDate { get; private set;}
    }
}
