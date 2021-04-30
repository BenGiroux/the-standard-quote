using ContractorJobBuilderV2.Web.ApiModels;
using FluentValidation;

namespace ContractorJobBuilderV2.Web.Validators
{
    public class JobTaskItemForCreationDtoValidator : AbstractValidator<JobTaskItemForCreationDto>
    {
        public JobTaskItemForCreationDtoValidator()
        {
            RuleFor(jt => jt.Summary).MaximumLength(1000);
        }
    }
}
