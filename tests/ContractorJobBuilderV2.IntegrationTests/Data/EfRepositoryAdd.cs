using System.Linq;
using System.Threading.Tasks;
using ContractorJobBuilderV2.Core;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using Xunit;

namespace ContractorJobBuilderV2.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsCarpentryJob()
        {
            var repository = GetRepository<JobId>();
            var industry = Industry.Carpentry;
            var job = industry.CreateJobForIndustry("Test job", "Test description");

            await repository.AddAsync(job);

            var newItem = (await repository.ListAsync<Job>())
                            .FirstOrDefault();

            Assert.IsType<JobId>(job.Id);
            Assert.Equal(IndustryType.Carpentry, newItem.IndustryId);
            Assert.Equal(newItem.Id, job.Id);
        }
    }
}
