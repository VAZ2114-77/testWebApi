using Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
	public class StoreContext : DbContext
	{
		public StoreContext(DbContextOptions<StoreContext> options) : base(options) { }

		public DbSet<User> Users { get; set; }
		public DbSet<Permission> Permissions { get; set; }
		public DbSet<ContentType> ContentTypes { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<AdminLog> AdminLogs { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<Cart> Carts { get; set; }
		public DbSet<Session> Sessions { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.Property(u => u.UserID)
				.UseIdentityColumn();

			modelBuilder.Entity<User>()
				.HasKey(u => u.UserID);

			modelBuilder.Entity<AdminLog>()
				.Property(a => a.LogID)
				.UseIdentityColumn();

			modelBuilder.Entity<AdminLog>()
				.HasKey(a => a.LogID);

			modelBuilder.Entity<Cart>()
				.Property(c => c.CartID)
				.UseIdentityColumn();

			modelBuilder.Entity<Cart>()
				.HasKey(c => c.CartID);

			modelBuilder.Entity<ContentType>()
				.Property(c => c.ContentTypeID)
				.UseIdentityColumn();

			modelBuilder.Entity<ContentType>()
				.HasKey(c => c.ContentTypeID);

			modelBuilder.Entity<Group>()
				.Property(g => g.GroupID)
				.UseIdentityColumn();

			modelBuilder.Entity<Group>()
				.HasKey(g => g.GroupID);

			modelBuilder.Entity<Order>()
				.Property(o => o.OrderID)
				.UseIdentityColumn();

			modelBuilder.Entity<Order>()
				.HasKey(o => o.OrderID);

			modelBuilder.Entity<Permission>()
				.Property(p => p.PermissionID)
				.UseIdentityColumn();

			modelBuilder.Entity<Permission>()
				.HasKey(p => p.PermissionID);

			modelBuilder.Entity<Product>()
				.Property(p => p.ProductID)
				.UseIdentityColumn();

			modelBuilder.Entity<Product>()
				.HasKey(p => p.ProductID);

			modelBuilder.Entity<Session>()
				.Property(s => s.SessionID)
				.UseIdentityColumn();

			modelBuilder.Entity<Session>()
				.HasKey(s => s.SessionID);




			modelBuilder.Entity<User>()
				.HasIndex(u => u.Username)
				.IsUnique();

			modelBuilder.Entity<User>()
				.HasIndex(u => u.Email)
				.IsUnique();		

			modelBuilder.Entity<Product>()
			  .Property(p => p.Price)
			.HasColumnType("decimal(18,2)");

			modelBuilder.Entity<Product>()
				.HasIndex(u => u.Name);

			modelBuilder.Entity<Order>()
				.HasIndex(u => u.Status);
		}
	}
}
