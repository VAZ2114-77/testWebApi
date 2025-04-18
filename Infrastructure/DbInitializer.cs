using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
	public static class DbInitializer
	{
		public static void Initialize(StoreContext context)
		{
			context.Database.EnsureCreated();

			if (context.Permissions.Any())
			{
				return;
			}

			var permissions = new Permission[]
			{
			new Permission{Name="Admin", Description="Full access"},
			new Permission{Name="Moderator", Description="Moderate content"},
			new Permission{Name="User", Description="Regular user"}
			};

			foreach (var p in permissions)
			{
				context.Permissions.Add(p);
			}
			context.SaveChanges();

			// Добавьте другие начальные данные по аналогии
		}
	}
}
