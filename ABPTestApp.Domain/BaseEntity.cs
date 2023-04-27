namespace ABPTestApp.Domain
{
    //Эта сущность создана для большего абстагирования других
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
