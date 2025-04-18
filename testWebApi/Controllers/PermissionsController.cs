using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace testWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PermissionsController : ControllerBase
	{
		private readonly StoreContext _context;

		public PermissionsController(StoreContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Permission>>> GetPermissions()
		{
			return await _context.Permissions.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Permission>> GetPermission(int id)
		{
			var permission = await _context.Permissions.FindAsync(id);

			if (permission == null)
			{
				return NotFound();
			}

			return permission;
		}

		[HttpPost]
		public async Task<ActionResult<Permission>> PostPermission(Permission permission)
		{
			_context.Permissions.Add(permission);
			await _context.SaveChangesAsync();

			return CreatedAtAction(nameof(GetPermission), new { id = permission.PermissionID }, permission);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutPermission(int id, Permission permission)
		{
			if (id != permission.PermissionID)
			{
				return BadRequest();
			}

			_context.Entry(permission).State = EntityState.Modified;

			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!PermissionExists(id))
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
		public async Task<IActionResult> DeletePermission(int id)
		{
			var permission = await _context.Permissions.FindAsync(id);
			if (permission == null)
			{
				return NotFound();
			}

			_context.Permissions.Remove(permission);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool PermissionExists(int id)
		{
			return _context.Permissions.Any(e => e.PermissionID == id);
		}
	}
}
