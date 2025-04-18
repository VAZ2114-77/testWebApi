using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
	public class User
	{
		public int UserID { get; set; }

		[Required]
		[StringLength(50)]
		public string Username { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string PasswordHash { get; set; }

		public DateTime RegistrationDate { get; set; } = DateTime.UtcNow;

		public DateTime? LastLogin { get; set; }

		public ICollection<Permission> Permissions { get; set; }
		public Cart Cart { get; set; }
		public ICollection<Session> Sessions { get; set; }
		public ICollection<Order> Orders { get; set; }
		public ICollection<Group> Groups { get; set; }
		public User()
		{
			Permissions = new List<Permission>();
		}

		public void AddDefaultPermission(Permission permission)
		{
			if (permission != null && !Permissions.Any(p => p.Name == permission.Name))
			{
				Permissions.Add(permission);
			}
		}

		
	}
}
