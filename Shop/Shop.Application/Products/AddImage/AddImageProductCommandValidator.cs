using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Products.AddImage
{
    public class AddImageProductCommandValidator:AbstractValidator<AddImageProductCommand>
    {
        public AddImageProductCommandValidator()
        {
            RuleFor(c => c.ImageFile).NotNull().WithMessage(ValidationMessages.required("عکس")).JustImageFile();
            RuleFor(c=>c.Sequence).GreaterThanOrEqualTo(0);
        }
    }
}
