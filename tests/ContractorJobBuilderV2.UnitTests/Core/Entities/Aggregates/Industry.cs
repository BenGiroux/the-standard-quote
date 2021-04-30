using ContractorJobBuilderV2.Core.Entities.Aggregates;
using System;
using Xunit;
using static ContractorJobBuilderV2.Core.IndustryType;

namespace ContractorJobBuilderV2.UnitTests.Core.Entities.Aggregates
{
    public class IndustryTests
    {
        [Fact]
        public void AddJobToIndustry()
        {
            Industry industry = Industry.Carpentry;

            Job job = industry.CreateJobForIndustry("Carpentry Job", "");

            Assert.NotNull(job);
            Assert.Equal(Carpentry, job.IndustryId);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void AddJobToIndustry_WithNullOrEmptyTitle_ReturnsError(string title)
        {
            Industry industry = Industry.Carpentry;

            Assert.ThrowsAny<Exception>(() => industry.CreateJobForIndustry(title, ""));
        }
    }
}
