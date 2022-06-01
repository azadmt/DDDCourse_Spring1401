using System;

namespace Framework.Persistence
{
    public class OutBoxMessage
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public bool IsSynced { get; set; }
    }
}
