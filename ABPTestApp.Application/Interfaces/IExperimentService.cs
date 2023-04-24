using ABPTestApp.Domain;

namespace ABPTestApp.Application.Interfaces
{
    public interface IExperimentService
    {
        Task<Experiment> GetButtonColorAsync(string deviceToken);
        string GetPrice(string deviceToken);
    }
}
