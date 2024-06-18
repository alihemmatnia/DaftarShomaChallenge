using DaftarShomaChallenge.Core.Domain.Entities.Base;

namespace DaftarShomaChallenge.Core.Domain.Entities
{
	public class Order : BaseEntity<int>
	{
		public string Number { get; private set; }
		public ICollection<OrderLine> OrderLines { get; private set; }
		public long TotalPrice { get; private set; }
		public DateTime Date { get; private set; }

		public Order (string number)
		{
			Number = number;
			Date = DateTime.Now;
		}

		#region Behaviour
		public void AddOrderLine (OrderLine line)
		{
			OrderLines.Add(line);
		}

		public void SetTotalPrice (long totalPrice)
		{
			TotalPrice = totalPrice;
		}
		#endregion
	}
}
