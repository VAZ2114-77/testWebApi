using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Session
	{
		public int SessionID { get; set; }

		[Required]
		public int UserID { get; set; }

		[Required]
		public string Token { get; set; }

		[Required]
		public DateTime ExpiresAt { get; set; }

		public User User { get; set; }
	}
}
