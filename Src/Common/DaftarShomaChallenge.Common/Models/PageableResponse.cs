using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaftarShomaChallenge.Common.Models
{
	public class PageableResponse<TEntity>
	{
		public PageableResponse (List<TEntity> entities, long total)
		{
			Values = entities;
			Count = total;
		}
		public List<TEntity> Values { get; set; }
		public long Count { get; set; }
	}
}
