using DaftarShomaChallenge.Core.Domain.Entities.Base;

namespace DaftarShomaChallenge.Core.Domain.Entities
{
	public class OrderLine : BaseEntity<int>
	{
		public Product Product { get; private set; }
		public int Quantity { get; private set; }
		public int Price { get; private set; }

		public OrderLine (Product product, int quantity, int price)
		{
			QuantityValidation(quantity);

			Product = product;
			Quantity = quantity;
			Price = price;
		}

		
		private void QuantityValidation (int quantity)
		{
			if (quantity < 1)
				throw new Exception("quantity can't be less than 1");
		}
	}
}
