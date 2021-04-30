using AutoMapper;
using ContractorJobBuilderV2.Core.Entities.Aggregates;
using ContractorJobBuilderV2.Core.ValueObjects;
using ContractorJobBuilderV2.SharedKernel.Interfaces;
using ContractorJobBuilderV2.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Controllers.Api
{
    [Route("api/industries")]
    public class IndustriesController : BaseApiController
    {
        private readonly IRepository<IndustryId> _repository;
        private readonly IMapper _mapper;

        public IndustriesController(IRepository<IndustryId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [HttpHead]
        public async Task<ActionResult<List<JobDto>>> GetIndustries()
        {
            var items = await _repository.ListAsync<Industry>();

            return Ok(_mapper.Map<List<IndustryDto>>(items));
        }

        [HttpOptions]
        public IActionResult GetIndustriesOptions()
        {
            Response.Headers.Add("Allow", "GET");
            return Ok();
        }
    }
}
