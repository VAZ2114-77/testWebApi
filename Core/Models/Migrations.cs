using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	internal class Migrations
	{
		public int MigrationID { get; set; }

		[Required]
		[StringLength(200)]
		public string Name { get; set; }

		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public DateTime AppliedAt { get; set; } = DateTime.UtcNow;
	}
}
