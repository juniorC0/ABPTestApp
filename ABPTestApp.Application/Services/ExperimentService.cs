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

        //Присваивание девайсу случайной опции 
        public async Task<Experiment> GetButtonColorAsync(string deviceToken)
        {
            var colorExperiments = await _repository.GetExperimentsByNameAsync("button-color");
            var rndColor = colorExperiments[new Random().Next(0, colorExperiments.Count)];
            var devices = await _repository.GetAllAsync<Device>();
            var device = devices.FirstOrDefault(x => x.Token == deviceToken);

            if (device != null)
            {
                return device.Experiment;
            }

            var newDevice = new Device()
            {
                Token = deviceToken,
                Experiment = rndColor,
                ExperimentId = rndColor.Id,
                CreationDate = DateTime.Now
            };

            await _repository.AddAsync(newDevice);
            await _repository.SaveChangesAsync();

            return newDevice.Experiment;
        }

        public async Task<Experiment> GetPriceAsync(string deviceToken)
        {
            var priceExperiments = await _repository.GetExperimentsByNameAsync("price");
            int[] weights = new int[] { 75, 10, 5, 10 };
            var devices = await _repository.GetAllAsync<Device>();
            var device = devices.FirstOrDefault(x => x.Token == deviceToken);
            
            if (device is not null)
            {
                return device.Experiment;
            }
            
            var rndPrice = GetWeightedRandom(priceExperiments, weights);

            var newDevice = new Device()
            {
                Token = deviceToken,
                Experiment = rndPrice,
                ExperimentId = rndPrice.Id,
                CreationDate = DateTime.Now
            };

            await _repository.AddAsync(newDevice);
            await _repository.SaveChangesAsync();

            return newDevice.Experiment;
        }

        //Для присваивания девайсу определенной опции в определенном проценте случаев я использовал алгоритм
        //Weighted Random Selection
        private Experiment GetWeightedRandom(List<Experiment> experiments, int[] weights)
        {
            if (experiments.Count != weights.Length)
            {
                throw new ArgumentException("The length of the experiments and weights arrays must be equal.");
            }

            if (experiments.Count < 1)
            {
                throw new InvalidOperationException("Count can`t be less than 1");
            }

            var totalWeight = weights.Sum();

            var rnd = new Random().Next(0, totalWeight);

            for (var i = 0; i < experiments.Count; i++)
            {
                if (rnd < weights[i])
                {
                    return experiments[i];
                }

                rnd -= weights[i];
            }

            return experiments.Last();
        }
    }
}
