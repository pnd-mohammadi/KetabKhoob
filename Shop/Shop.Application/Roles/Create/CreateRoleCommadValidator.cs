using Common.Application.Validation;
using FluentValidation;

namespace Shop.Application.Roles.Create
{
    public class CreateRoleCommadValidator : AbstractValidator<CreateRoleCommand>
    {
        public CreateRoleCommadValidator() 
        {
            RuleFor(f=>f.Title).NotEmpty().WithMessage(ValidationMessages.required("عنوان")) ;
        }
    }

}
