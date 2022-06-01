using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadModel.DAL.DataModel
{

    public class AccountModel
    {
        public Guid Id { get; set; }

        public Guid OwnerId { get; set; }

        public string OwnerName { get; set; }

        public string Number { get; set; }

        public decimal Balance { get; set; }

        public string Type { get; set; }

        public string State { get; set; }
    }
}
