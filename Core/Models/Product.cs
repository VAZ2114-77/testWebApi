using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Product
	{
		public int ProductID { get; set; }

		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		public string Description { get; set; }

		[Required]
		[Range(0.01, double.MaxValue)]
		public decimal Price { get; set; }

		[Range(0, int.MaxValue)]
		public int StockQuantity { get; set; } = 0;
		public ICollection<Cart> Carts { get; set; }
	}
}
