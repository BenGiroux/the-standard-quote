using ContractorJobBuilderV2.Web.ApiModels;
using FluentValidation;

namespace ContractorJobBuilderV2.Web.Validators
{
    public class JobForUpdateDtoValidator : AbstractValidator<JobForCreationDto>
    {
        public JobForUpdateDtoValidator()
        {
            RuleFor(j => j.Title).NotEmpty().Length(0, 255);
            RuleFor(j => j.Description).MaximumLength(500);
            RuleForEach(j => j.JobTasks).SetValidator(new JobTaskForCreationDtoValidator());
        }
    }
}
