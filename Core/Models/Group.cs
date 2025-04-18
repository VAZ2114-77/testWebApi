using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Group
	{
		public int GroupID { get; set; }

		[Required]
		[StringLength(100)]
		public string Name { get; set; }

		public string Description { get; set; }
		public ICollection<User> Users { get; set; }
	}
}
