namespace ABPTestApp.Domain
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
