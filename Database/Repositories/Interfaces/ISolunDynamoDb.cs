using Database.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Repositories.Interfaces
{
	public interface ISolunDynamoDb
	{
		Task AddWatch(WatchDb watchDb);
		Task<IEnumerable<WatchDb>> GetAllWatches();
		Task<int> GetNextUserIdAsync();
	}
}
