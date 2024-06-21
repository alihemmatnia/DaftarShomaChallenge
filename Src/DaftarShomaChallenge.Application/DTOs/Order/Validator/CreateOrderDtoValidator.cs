using FluentValidation;

namespace DaftarShomaChallenge.Application.DTOs.Order.Validator
{
	public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
	{
		public CreateOrderDtoValidator ()
		{
			RuleForEach(c => c.OrderLines).SetValidator(new OrderLineDtoValidator());
		}
	}
}
