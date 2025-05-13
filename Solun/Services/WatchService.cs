using Database.Mappers.Interfaces;
using Database.Repositories.Interfaces;
using Models;
using Solun.Services.Interfaces;

namespace Solun.Services
{
	public class WatchService : IWatchService
	{
		private readonly ISolunDynamoDb solunDynamoDb;
		private readonly IMapper mapper;

		public WatchService(ISolunDynamoDb solunDynamoDb, IMapper mapper )
		{
			this.solunDynamoDb = solunDynamoDb;
			this.mapper = mapper;
		}
		public async IAsyncEnumerable<WatchAddedResult> AddWatches(IEnumerable<Watch> watches)
		{
			foreach(var watch in watches)
			{
				yield return await AddWatch(watch);
			}
		}
		public async Task<WatchAddedResult> AddWatch(Watch watch)
		{
			var watchID = await GetNextUserIdAsync();
			watch.id = watchID;
			var watchDb = mapper.ToWatchDb(watch);
			await solunDynamoDb.AddWatch(watchDb);
			return new WatchAddedResult
			{
				ID = watchID,
				name = watch.name,
			};
		}

		public async Task<IEnumerable<Watch>> GetWatches()
		{
			var watchesDb = await solunDynamoDb.GetAllWatches();
			return mapper.ToWatch(watchesDb);
		}

		private async Task<int> GetNextUserIdAsync()
		{
			return await solunDynamoDb.GetNextUserIdAsync();
		}
	}
}
