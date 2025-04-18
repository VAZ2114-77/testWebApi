using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class ContentType
	{
		public int ContentTypeID { get; set; }

		[Required]
		[StringLength(100)]
		public string TypeName { get; set; }

		public ICollection<Permission> Permissions { get; set; }
	}
}
