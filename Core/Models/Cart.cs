using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Cart
	{
		public int CartID { get; set; }

		[Required]
		public int UserID { get; set; }

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

		public User User { get; set; }
		public ICollection<Product> Products { get; set; }
	}
}
