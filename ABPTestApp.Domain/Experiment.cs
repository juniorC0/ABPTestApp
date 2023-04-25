using System.Text.Json.Serialization;

namespace ABPTestApp.Domain
{
    public class Experiment : BaseEntity
    {
        public string Name { get; set; }
        public string Option { get; set; }

        [JsonIgnore]
        public ICollection<Device> Devices { get; set; }
    }
}
