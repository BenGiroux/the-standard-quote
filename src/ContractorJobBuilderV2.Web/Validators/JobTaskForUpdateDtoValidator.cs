using ContractorJobBuilderV2.Web.ApiModels;
using FluentValidation;

namespace ContractorJobBuilderV2.Web.Validators
{
    public class JobTaskForUpdateDtoValidator : AbstractValidator<JobTaskForCreationDto>
    {
        public JobTaskForUpdateDtoValidator()
        {
            RuleFor(jt => jt.Title).NotEmpty().Length(0, 255);
            RuleFor(jt => jt.Description).MaximumLength(500);
            RuleFor(jt => jt.Order).GreaterThanOrEqualTo(0);
        }
    }
}
