using FluentValidation;

namespace DaftarShomaChallenge.Application.DTOs.Order.Validator
{
	public class GetSalesBetweenDateDtoValidator : AbstractValidator<GetSalesBetweenDateDto>
	{
		public GetSalesBetweenDateDtoValidator ()
		{
			RuleFor(x => x.EndDate)
			.Must(x => x <= DateTime.Now).WithMessage("تاریخ پایان باید کمتر از تاریخ الان باشد");

			RuleFor(x => new { x.StartDate, x.EndDate })
				.Must(x => x.StartDate < x.EndDate)
									  .WithMessage("تاریخ شروع باید کمتر از تاریخ پایان باشد");
		}
	}
}
