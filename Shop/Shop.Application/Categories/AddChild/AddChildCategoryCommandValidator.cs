using Common.Application.Validation;
using FluentValidation;
using Shop.Application.Categories.Edit;

namespace Shop.Application.Categories.AddChild;

public class AddChildCategoryCommandValidator: AbstractValidator<EditCategoryCommand>
{
    public AddChildCategoryCommandValidator()
        {
        RuleFor(c => c.title).NotNull().NotEmpty().WithMessage(ValidationMessages.required("title"));
        RuleFor(c => c.slug).NotNull().NotEmpty().WithMessage(ValidationMessages.required("slug"));
    }
}
