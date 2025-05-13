using Microsoft.AspNetCore.Mvc;
using Models;
using Solun.Services.Interfaces;

namespace Solun.Controllers
{
	[ApiController]
	[Route("api/watches")]
	public class Watches : Controller
	{
		private readonly IWatchService watchService;

		public Watches(IWatchService watchService)
		{
			this.watchService = watchService;
		}
		[HttpGet]
		public async Task<IEnumerable<Watch>> GetWatchesAsync()
		{
			return await watchService.GetWatches();
		}
		[HttpPost]
		public async Task<IActionResult> AddWatchAsync([FromBody] Watch watch)
		{
			var result = await watchService.AddWatch(watch);
			return Ok(result);
		}

		[HttpPost]
		[Route("bulk")]
		public async Task<IActionResult> AddWatchesAsync([FromBody] IEnumerable<Watch> watches)
		{
			var watchResults = new List<WatchAddedResult>();
			await foreach (var item in watchService.AddWatches(watches))
			{
				watchResults.Add(item);
			}
			return Ok(watchResults);
		}
	}
}
