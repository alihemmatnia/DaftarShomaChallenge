using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaftarShomaChallenge.Application.DTOs.Order
{
	public record GetSalesBetweenDateDto
	{
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
