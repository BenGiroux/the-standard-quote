using AutoMapper;
using ContractorJobBuilderV2.Core;
using ContractorJobBuilderV2.Core.Specifications;
using ContractorJobBuilderV2.Core.ValueObjects;
using ContractorJobBuilderV2.SharedKernel.Interfaces;
using ContractorJobBuilderV2.Web.ApiModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ContractorJobBuilderV2.Controllers.Api
{
    [Route("api/industries/{industryId:int}/jobs")]
    public class JobTasksController : BaseApiController
    {
        private readonly IRepository<JobId> _repository;
        private readonly IMapper _mapper;

        public JobTasksController(IRepository<JobId> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("{jobId:Guid}/jobtask")]
        public async Task<ActionResult<JobDto>> CreateJobTask(int industryId, Guid jobId, [FromBody] JobTaskForCreationDto request)
        {
            if (!IndustryType.TryFromValue(industryId, out IndustryType industryType))
            {
                return NotFound();
            }

            var existingJob = await _repository.GetByIdAsync(new GetJobWithTasksSpecification(new JobId(jobId)));

            if (existingJob == null || existingJob.IndustryId != industryType.Value)
            {
                return NotFound();
            }

            if (request.Order.HasValue)
            {
                existingJob.InsertNewJobTaskAt(new TitleAndDescription(request.Title, request.Description), request.Order.Value);
            }
            else
            {
                existingJob.AddNewJobTask(new TitleAndDescription(request.Title, request.Description));
            }

            await _repository.UpdateAsync(existingJob);

            return CreatedAtRoute(
                "GetJob",
                new { industryId, jobId },
                _mapper.Map<JobDto>(existingJob)
            );
        }

        [HttpPut("{jobId:Guid}/jobtask/{jobTaskId:Guid}")]
        public async Task<ActionResult<JobDto>> UpdateJobTask(int industryId, Guid jobId, Guid jobTaskId, [FromBody] JobTaskForUpdateDto request)
        {
            if (!IndustryType.TryFromValue(industryId, out IndustryType industryType))
            {
                return NotFound();
            }

            var existingJob = await _repository.GetByIdAsync(new GetJobWithTasksSpecification(new JobId(jobId)));

            if (existingJob == null || existingJob.IndustryId != industryType.Value)
            {
                return NotFound();
            }

            existingJob.UpdateJobTask(
                new JobTaskId(jobTaskId),
                new TitleAndDescription(request.Title, request.Description),
                request.Order.Value,
                request.JobTaskItems.Select(jti => _mapper.Map<JobTaskItem>(jti))
            );

            await _repository.UpdateAsync(existingJob);

            return CreatedAtRoute(
                "GetJob",
                new { industryId, jobId },
                _mapper.Map<JobDto>(existingJob)
            );
        }

        [HttpOptions]
        public IActionResult GetJobTasksOptions()
        {
            Response.Headers.Add("Allow", "POST, PUT");
            return Ok();
        }
    }
}
