using Framework.Core;
using System;

namespace CustomerManagement.Domain
{
    public class Customer : Entity<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
