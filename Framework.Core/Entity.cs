using System.ComponentModel.DataAnnotations;

namespace Framework.Core
{
    public abstract class Entity<TKey>
    {
        [Key]
        public TKey Id { get; set; }

        public override bool Equals(object obj)
        {
            return Id.Equals(((Entity<TKey>)obj).Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }

    
}
