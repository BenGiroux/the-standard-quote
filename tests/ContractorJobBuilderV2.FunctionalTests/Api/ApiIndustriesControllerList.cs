using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ContractorJobBuilderV2.Core.Entities;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Web;
using ContractorJobBuilderV2.Web.ApiModels;
using Newtonsoft.Json;
using Xunit;

namespace ContractorJobBuilderV2.FunctionalTests.Api
{
    public class ApiIndustriesControllerList : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ApiIndustriesControllerList(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsThreeIndustries()
        {
            var response = await _client.GetAsync("/api/industries");
            response.EnsureSuccessStatusCode();
            var stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<IEnumerable<IndustryDto>>(stringResponse).ToList();

            Assert.Equal(3, result.Count());
            Assert.Contains(result, i => i.Title == Industry.Carpentry.TitleAndDescription.Title);
            Assert.Contains(result, i => i.Title == Industry.Electrical.TitleAndDescription.Title);
            Assert.Contains(result, i => i.Title == Industry.Plumbing.TitleAndDescription.Title);
        }
    }
}
