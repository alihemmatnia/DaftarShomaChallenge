using DaftarShomaChallenge.Core.Domain.Entities.Base;

namespace DaftarShomaChallenge.Core.Domain.Entities
{
	public class OrderLine : BaseEntity<int>
	{
		public int Quantity { get; private set; }
		public int Price { get; private set; }

		public Product Product { get; private set; }
		public Order Order { get; private set; }

		public OrderLine ()
		{

		}
		public OrderLine (Product product, int quantity)
		{
			QuantityValidation(quantity);

			Product = product;
			Quantity = quantity;
			Price = CalcPrice();
		}

		private int CalcPrice ()
		{
			return Product.Price * Quantity;
		}

		private void QuantityValidation (int quantity)
		{
			if (quantity < 1)
				throw new Exception("quantity can't be less than 1");
		}
	}
}
