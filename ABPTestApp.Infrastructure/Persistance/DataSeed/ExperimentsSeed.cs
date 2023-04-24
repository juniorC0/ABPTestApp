using ABPTestApp.Domain;
using Microsoft.EntityFrameworkCore;

namespace ABPTestApp.Infrastructure.Persistance.DataSeed
{
    public class ExperimentsSeed
    {
        public static async Task Seed(ExperimentDbContext dbContext)
        {
            dbContext.Database.Migrate();

            if (!dbContext.Experiments.Any())
            {
                var experiments = new[]
                {
                    new Experiment
                    {
                        Name = "button-color",
                        Option = "#FF0000",
                        CreationDate = DateTime.Now
                    },
                    new Experiment
                    {
                        Name = "button-color",
                        Option = "#00FF00",
                        CreationDate = DateTime.Now
                    },
                    new Experiment
                    {
                        Name = "button-color",
                        Option = "#0000FF",
                        CreationDate = DateTime.Now
                    },
                    new Experiment
                    {
                        Name = "price",
                        Option = "10",
                        CreationDate = DateTime.Now
                    },
                    new Experiment
                    {
                        Name = "price",
                        Option = "20",
                        CreationDate = DateTime.Now
                    },
                    new Experiment
                    {
                        Name = "price",
                        Option = "50",
                        CreationDate = DateTime.Now
                    },
                    new Experiment
                    {
                        Name = "price",
                        Option = "5",
                        CreationDate = DateTime.Now
                    }
                };

                await dbContext.Experiments.AddRangeAsync(experiments);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
