using ABPTestApp.Application.Interfaces;
using ABPTestApp.Domain;

namespace ABPTestApp.Application.Services
{
    public class ExperimentService : IExperimentService
    {
        private readonly IRepository _repository;

        public ExperimentService(IRepository repository)
        {
            _repository = repository;
        }


        public async Task<Experiment> GetButtonColorAsync(string deviceToken)
        {
            var random = new Random();
            var colors = await _repository.GetExperimentsByNameAsync("button-color");        
            var rndColor = colors[random.Next(0, colors.Count)];
            var devices = await _repository.GetAllAsync<Device>();
            var device = devices.FirstOrDefault(x => x.Token == deviceToken);

            if (device is not null)
            {
                return device.Experiment;
            }

            var newDevice = new Device()
            {
                Token = deviceToken,
                Experiment = rndColor,
                ExperimentId = rndColor.Id
            };

            await _repository.AddAsync(newDevice);
            await _repository.SaveChangesAsync();

            return newDevice.Experiment;
        }

        public string GetPrice(string deviceToken)
        {
            return "";
        }
    }
}
