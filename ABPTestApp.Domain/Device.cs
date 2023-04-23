namespace ABPTestApp.Domain
{
    public class Device
    {
        public int Id { get; set; }
        public string Token { get; set; }

        public string ExperimentId { get; set; }
        public Experiment Experiment { get; set; }
    }
}
