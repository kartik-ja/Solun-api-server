using Database.DatabaseModels;
using Models;

namespace Database.Mappers.Interfaces
{
	public interface IMapper
	{
		Watch ToWatch(WatchDb watchDb);
		IEnumerable<Watch> ToWatch(IEnumerable<WatchDb> watchDb);
		WatchDb ToWatchDb(Watch watchDb);
		IEnumerable<WatchDb> ToWatchDb(IEnumerable<Watch> watchDb);
	}
}
