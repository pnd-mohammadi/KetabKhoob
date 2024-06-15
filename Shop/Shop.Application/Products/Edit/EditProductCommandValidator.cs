using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.Edit
{
    public class EditProductCommandValidator:AbstractValidator<EditProductCommand>
    {
        public EditProductCommandValidator()
        {
            RuleFor(c => c.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان"));
            RuleFor(c => c.Slug).NotEmpty().WithMessage(ValidationMessages.required("slug"));
            RuleFor(c => c.Description).NotEmpty().WithMessage(ValidationMessages.required("توضیحات"));
            RuleFor(c => c.ImageFile).JustImageFile();
        }
    }
}
