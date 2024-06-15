using FluentValidation;
using Common.Application.Validation;

namespace Shop.Application.Categories.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator() 
        {
            RuleFor(r => r.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("title"));
            RuleFor(r => r.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
        }
    }
}
