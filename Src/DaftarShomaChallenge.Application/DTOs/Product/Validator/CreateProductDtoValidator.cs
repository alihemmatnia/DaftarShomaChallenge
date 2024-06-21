using FluentValidation;

namespace DaftarShomaChallenge.Application.DTOs.Product.Validator
{
	public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
	{
		public CreateProductDtoValidator ()
		{
			RuleFor(c => c.Title)
				 .NotNull().WithMessage("عنوان محصول نمی تواند خالی باشد")
				 .MaximumLength(200).WithMessage("عنوان محصول باید کمتر از 200 کاراکتر باشد");
		}
	}
}
