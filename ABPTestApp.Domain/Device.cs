namespace ABPTestApp.Domain
{
    public class Device : BaseEntity
    {
        public string Token { get; set; }

        public int ExperimentId { get; set; }
        public Experiment Experiment { get; set; }
    }
}
