namespace Loan.Framework.Commons.Entities
{
    public class Entity<T> : AuditableEntity where T : struct
    {
        protected Entity()
        {

        }
        protected Entity(T id)
        {

        }
        public T Id { get; protected set; }
    }
}
