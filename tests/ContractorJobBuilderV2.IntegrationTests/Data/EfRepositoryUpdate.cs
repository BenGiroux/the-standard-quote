using System;
using System.Linq;
using System.Threading.Tasks;
using ContractorJobBuilderV2.Core.Entities;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using ContractorJobBuilderV2.UnitTests;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ContractorJobBuilderV2.IntegrationTests.Data
{
    public class EfRepositoryUpdate : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task UpdatesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository<JobId>();
            var industry = Industry.Carpentry;
            var job = industry.CreateJobForIndustry("Test job", "Test description");

            await repository.AddAsync(job);

            // detach the item so we get a different instance
            _dbContext.Entry(job).State = EntityState.Detached;

            // fetch the item and update its title
            var singleJob = (await repository.ListAsync<Job>())
                .FirstOrDefault(i => i.TitleAndDescription.Title == "Test job");
            Assert.NotNull(singleJob);
            Assert.NotSame(job, singleJob);

            singleJob.UpdateTitleAndDescription(new TitleAndDescription("Updated job", ""));

            // Update the item
            await repository.UpdateAsync(singleJob);
            var updatedItem = (await repository.ListAsync<Job>())
                .FirstOrDefault(i => i.TitleAndDescription.Title == "Updated job");

            Assert.NotNull(updatedItem);
            Assert.NotEqual(job.TitleAndDescription.Title, updatedItem.TitleAndDescription.Title);
            Assert.Equal(singleJob.Id, updatedItem.Id);
        }
    }
}
