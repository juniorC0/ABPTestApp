using ABPTestApp.Domain;

namespace ABPTestApp.Application.Interfaces
{
    public interface IExperimentService
    {
        Task<Experiment> GetButtonColorAsync(string deviceToken);
        Task<Experiment> GetPriceAsync(string deviceToken);
        Task<ICollection<Device>> GetAllDevicesAsync();
    }
}
