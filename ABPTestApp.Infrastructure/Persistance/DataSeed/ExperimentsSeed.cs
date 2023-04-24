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
                        Option = "#FF0000"
                    },
                    new Experiment
                    {
                        Name = "button-color",
                        Option = "#00FF00"
                    },
                    new Experiment
                    {
                        Name = "button-color",
                        Option = "#0000FF"
                    },
                    new Experiment
                    {
                        Name = "price",
                        Option = "10"
                    },
                    new Experiment
                    {
                        Name = "price",
                        Option = "20"
                    },
                    new Experiment
                    {
                        Name = "price",
                        Option = "50"
                    },
                    new Experiment
                    {
                        Name = "price",
                        Option = "5"
                    }
                };

                await dbContext.Experiments.AddRangeAsync(experiments);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
