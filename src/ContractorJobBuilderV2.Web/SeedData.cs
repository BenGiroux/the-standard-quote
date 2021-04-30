using System;
using System.Linq;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContractorJobBuilderV2.Web
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var dbContext = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>(), null))
            {
                // Look for any Industries
                if (dbContext.Industries.Any())
                {
                    return;   // DB has been seeded
                }

                PopulateTestData(dbContext);
            }
        }
        public static void PopulateTestData(AppDbContext dbContext)
        {
            foreach (var item in dbContext.Industries)
            {
                dbContext.Remove(item);
            }
            dbContext.SaveChanges();
            dbContext.Industries.Add(Industry.Carpentry);
            dbContext.Industries.Add(Industry.Electrical);
            dbContext.Industries.Add(Industry.Plumbing);

            dbContext.SaveChanges();
        }
    }
}
