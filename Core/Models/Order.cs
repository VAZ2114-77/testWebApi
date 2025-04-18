using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Order
	{
		public int OrderID { get; set; }

		[Required]
		public int UserID { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime OrderDate { get; set; } = DateTime.UtcNow;

		[Required]
		[StringLength(50)]
		public string Status { get; set; }

		[Required]
		[Range(0.01, double.MaxValue)]
		public decimal TotalAmount { get; set; }

		public User User { get; set; }

	}
}
