
using FluentValidation;
using HHGlobal.PrintCalculator.API.Queries;
using HHGlobal.PrintCalculator.API.Requests;

namespace HHGlobal.PrintCalculator.API.Validation;

public class CalculateJobRequestValidator : AbstractValidator<CalculateJobsQuery>
{
    public CalculateJobRequestValidator(IValidator<JobItemRequest> jobItemRequestValidator)
    {
        RuleFor(e => e.Model.ExtraMargin).Must(BeValidMarginInput).WithMessage("Margin has to be either empty or \"extra-margin\"");
        RuleFor(e => e.Model.JobItems).NotNull().NotEmpty();
        RuleForEach(e => e.Model.JobItems).SetValidator(jobItemRequestValidator);
    }

    public bool BeValidMarginInput(string? margin)
    {
        return margin is null || margin == "extra-margin";
    }
}