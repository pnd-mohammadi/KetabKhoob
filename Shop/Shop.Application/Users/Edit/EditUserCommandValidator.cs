using Common.Application.Validation;
using Common.Application.Validation.FluentValidations;
using FluentValidation;

namespace Shop.Application.Users.Edit
{
    public class EditUserCommandValidator:AbstractValidator<EditUserCommand>
    {
        public EditUserCommandValidator()
        {
            RuleFor(c => c.PhoneNumber).ValidPhoneNumber();
            RuleFor(c => c.Email).EmailAddress().WithMessage(ValidationMessages.required("ایمیل نامعتبر است"));
            RuleFor(c => c.Avatar).JustImageFile();


        }
    }
}
