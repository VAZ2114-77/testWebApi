using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class Permission
	{
		public int PermissionID { get; set; }

		[Required]
		[StringLength(50)]
		public string Name { get; set; }

		public string Description { get; set; }

		public ICollection<User> Users { get; set; }
		public ICollection<Group> Groups { get; set; }
		public ICollection<ContentType> ContentTypes { get; set; }
	}
}
