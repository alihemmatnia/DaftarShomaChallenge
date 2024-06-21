using DaftarShomaChallenge.Core.Domain.Entities.Base;

namespace DaftarShomaChallenge.Core.Domain.Entities
{
	public class Order : BaseEntity<int>
	{
		public string Number { get; private set; }
		public ICollection<OrderLine> OrderLines { get; private set; }
		public long TotalPrice { get; private set; }
		public DateTime Date { get; private set; }

        public Order ()
		{
			Date = DateTime.Now;
		}

		#region Behaviour
		public void AddOrderLine (OrderLine line)
		{
			if(OrderLines == null) OrderLines = [];

			OrderLines.Add(line);
		}

		public void CalcTotalPrice ()
		{
			TotalPrice = OrderLines.Sum(o => o.Price); 
		}

		public void SetNumber (string number)
		{
			Number = number;
		}
		#endregion
	}
}
