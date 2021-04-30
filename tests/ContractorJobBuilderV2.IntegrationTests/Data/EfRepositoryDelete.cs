using System;
using System.Threading.Tasks;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using Xunit;

namespace ContractorJobBuilderV2.IntegrationTests.Data
{
    public class EfRepositoryDelete : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task DeletesItemAfterAddingIt()
        {
            // add an item
            var repository = GetRepository<JobId>();
            var industry = Industry.Carpentry;
            var job = industry.CreateJobForIndustry("Test job", "Test description");
            await repository.AddAsync(job);

            // delete the item
            await repository.DeleteAsync(job);

            // verify it's no longer there
            Assert.DoesNotContain(await repository.ListAsync<Job>(),
                j => j.TitleAndDescription.Title == "Test job");
        }
    }
}
