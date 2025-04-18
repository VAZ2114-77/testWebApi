using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace testWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly StoreContext _context;

		public UsersController(StoreContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<object>>> GetUsers()
		{
			return await _context.Users
				.Include(u => u.Permissions)
				.Select(u => new
				{
					u.UserID,
					u.Username,
					u.Email,
					Permissions = u.Permissions.Select(p => new
					{
						p.PermissionID,
						p.Name
					})
				})
				.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<User>> GetUser(int id)
		{
			var user = await _context.Users
				.Include(u => u.Permissions)
				.FirstOrDefaultAsync(u => u.UserID == id);

			if (user == null)
			{
				return NotFound();
			}

			return Ok(new
				{
					user.UserID,
					user.Username,
					user.Email,
					Permissions = user.Permissions?.Select(p => new
					{
						p.PermissionID,
						p.Name
					})
				});
		}

		[HttpPost]
		public async Task<ActionResult<User>> PostUser(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetUser), new { id = user.UserID }, user);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutUser(int id, User user)
		{
			if (id != user.UserID)
			{
				return BadRequest();
			}

			_context.Entry(user).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!UserExists(id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}

			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user == null)
			{
				return NotFound();
			}

			_context.Users.Remove(user);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool UserExists(int id)
		{
			return _context.Users.Any(e => e.UserID == id);
		}
	}
}
