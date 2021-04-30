using ContractorJobBuilderV2.Core;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.Specifications;
using ContractorJobBuilderV2.Core.ValueObjects;
using System.Threading.Tasks;
using Xunit;

namespace ContractorJobBuilderV2.IntegrationTests.Data
{
    public class EfRepositorySpecifications : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task GetJobWithJobTasksEFSpecification()
        {
            var repository = GetRepository<JobId>();
            Industry industry = Industry.Carpentry;
            var job = industry.CreateJobForIndustry("Job");

            job.AddNewJobTask(new TitleAndDescription("Job Task", ""));
            job.AddNewJobTask(new TitleAndDescription("Job Task 2", ""));
            job.AddNewJobTask(new TitleAndDescription("Job Task 3", ""));

            await repository.AddAsync(job);

            var singleJob = await repository
                    .GetByIdAsync(new GetJobWithTasksSpecification(new JobId(job.Id.Id)));

            Assert.NotEmpty(singleJob.JobTasks);
            Assert.True(singleJob.TitleAndDescription.Title == "Job");
            Assert.True(singleJob.JobTasks.Count == 3);
        }

        [Fact]
        public async Task GetJobsWithJobTasksEFSpecification()
        {
            var repository = GetRepository<JobId>();
            Industry carpentryIndustry = Industry.Carpentry;
            var industryJob = carpentryIndustry.CreateJobForIndustry("Industry Job");
            Industry electricalIndustry = Industry.Electrical;
            var electricalJob = electricalIndustry.CreateJobForIndustry("Electrical Job");

            industryJob.AddNewJobTask(new TitleAndDescription("Job Task", ""));
            electricalJob.AddNewJobTask(new TitleAndDescription("Job Task", ""));

            await repository.AddAsync(industryJob);
            await repository.AddAsync(electricalJob);

            var singleIndustryJob = await repository.GetByIdAsync(new GetJobsWithTasksSpecification(IndustryType.Carpentry));

            Assert.NotEmpty(singleIndustryJob.JobTasks);
            Assert.True(singleIndustryJob.TitleAndDescription.Title == "Industry Job");
            Assert.True(singleIndustryJob.JobTasks.Count == 1);

            var singleElectricalJob = await repository.GetByIdAsync(new GetJobsWithTasksSpecification(IndustryType.Electrical));

            Assert.NotEmpty(singleElectricalJob.JobTasks);
            Assert.True(singleElectricalJob.TitleAndDescription.Title == "Electrical Job");
            Assert.True(singleElectricalJob.JobTasks.Count == 1);
        }
    }
}
