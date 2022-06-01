using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core.Domian
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
    {
        public List<IEvent> Changes { get; private set; } = new List<IEvent>();
    }
}
