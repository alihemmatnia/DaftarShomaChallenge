using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DaftarShomaChallenge.Application.DTOs.Product
{
	public record ProductDto
	{
        public int Id { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
    }
}
