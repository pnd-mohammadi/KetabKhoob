using FluentValidation;

namespace Shop.Application.Orders.AddItem
{
    public class AddOrderItemCommandValidator : AbstractValidator<AddOrderItemCommand>
    {
        public AddOrderItemCommandValidator()
            {
            RuleFor(c => c.Count).GreaterThanOrEqualTo(1).WithMessage("تعداد باید بیشتر از 0 باشد");
            }
    }
}
