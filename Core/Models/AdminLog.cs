using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class AdminLog
	{
		public int LogID { get; set; }

		[Required]
		[StringLength(200)]
		public string Action { get; set; }
		public DateTime Timestamp { get; set; } = DateTime.UtcNow;

		public string Details { get; set; }

	}
}
