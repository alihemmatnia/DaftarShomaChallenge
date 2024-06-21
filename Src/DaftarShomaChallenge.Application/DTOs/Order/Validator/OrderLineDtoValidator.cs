using FluentValidation;

namespace DaftarShomaChallenge.Application.DTOs.Order.Validator
{
	public class OrderLineDtoValidator : AbstractValidator<OrderLineDto>
	{
		public OrderLineDtoValidator ()
		{
			RuleFor(x => x.Quantity)
				.NotNull().WithMessage("تعداد محصول باید بیشتر از 1 عدد باشد");

			RuleFor(x => x.ProductId)
				.NotNull().WithMessage("شناسه محصول را وارد کنید");
		}
	}
}
