namespace ABPTestApp.Domain
{
    public class Experiment : BaseEntity
    {
        public string Name { get; set; }
        public string Option { get; set; }

        public ICollection<Device> Devices { get; set; }
    }
}
