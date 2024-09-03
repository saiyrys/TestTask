using TestTask.ApplicationCore.Models;

namespace TestTask.Infrastructure.Data
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }

        public void SeedDataContext()
        {
            if (!dataContext.Areas.Any())
            {
                var areas = new List<Areas>
                {
                    new Areas
                    {
                        areasId = "1",
                        areasNumber = 3,
                    }
                };
                dataContext.Areas.AddRange(areas);
                dataContext.SaveChanges();
            }
        }
    }
}
