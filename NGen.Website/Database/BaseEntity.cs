namespace NGen
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        public BaseEntity()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
        }
    }
}
