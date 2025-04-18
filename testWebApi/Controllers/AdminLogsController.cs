using Core.Models;
using Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace testWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdminLogsController : ControllerBase
	{
		private readonly StoreContext _context;
		private readonly ILogger _logger;

		public AdminLogsController(ILogger logger, StoreContext context)
		{
			_logger = logger;
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<AdminLog>>> GetAdminLogs()
		{
			_logger.LogInformation("Req admin logs");
			return await _context.AdminLogs.ToListAsync();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<AdminLog>> GetAdminLog(int id)
		{
			_logger.LogInformation($"Req admin log id: {id}");
			var adminLog = await _context.AdminLogs.FindAsync(id);

			if (adminLog == null)
			{
				return NotFound();
			}

			return adminLog;
		}

		[HttpPost]
		public async Task<ActionResult<AdminLog>> PostAdminLog(AdminLog adminLog)
		{
			_context.AdminLogs.Add(adminLog);
			await _context.SaveChangesAsync();
			_logger.LogInformation($"Add admin log {adminLog}");

			return CreatedAtAction(nameof(GetAdminLog), new { id = adminLog.LogID }, adminLog);
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAdminLog(int id)
		{
			var adminLog = await _context.AdminLogs.FindAsync(id);
			if (adminLog == null)
			{
				return NotFound();
			}

			_context.AdminLogs.Remove(adminLog);
			await _context.SaveChangesAsync();

			return NoContent();
		}

		private bool AdminLogExists(int id)
		{
			return _context.AdminLogs.Any(e => e.LogID == id);
		}
	}
}
