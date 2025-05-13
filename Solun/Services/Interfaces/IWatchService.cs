using Models;

namespace Solun.Services.Interfaces
{
	public interface IWatchService
	{
		Task<IEnumerable<Watch>> GetWatches();
		Task<WatchAddedResult> AddWatch(Watch watch);
		IAsyncEnumerable<WatchAddedResult> AddWatches(IEnumerable<Watch> watches);
	}
}
