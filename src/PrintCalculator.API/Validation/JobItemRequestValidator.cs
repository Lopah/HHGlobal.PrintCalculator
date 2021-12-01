using FluentValidation;
using HHGlobal.PrintCalculator.API.Requests;

namespace HHGlobal.PrintCalculator.API.Validation;

public class JobItemRequestValidator : AbstractValidator<JobItemRequest>
{
    public JobItemRequestValidator()
    {
        RuleFor(e => e.Name).NotNull().NotEmpty().WithMessage("Name cannot be empty");
        RuleFor(e => e.Price).Must(e => e > 0).WithMessage("Price must be at-least 1 USD");
    }
    
}