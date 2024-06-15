using FluentValidation;
using Common.Application.Validation;

namespace Shop.Application.Categories.Edit
{
    public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
    {
        public EditCategoryCommandValidator() 
        {
            RuleFor(c => c.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("title"));
            RuleFor(c => c.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
        }
    }
}
