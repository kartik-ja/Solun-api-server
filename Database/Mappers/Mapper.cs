using Database.DatabaseModels;
using Database.Mappers.Interfaces;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Mappers
{
	public class Mapper : IMapper
	{
		public Watch ToWatch(WatchDb watchDb)
		{
			return new Watch()
			{
				id = watchDb.Id,
				name = watchDb.name,
				description = watchDb.description,
				price = watchDb.price,
				image = watchDb.image,
				category = watchDb.Category,

				strap = watchDb.filters.strap,
				dial_color = watchDb.filters.dial_color,
				case_material = watchDb.filters.case_material,
				case_diameter_mm = watchDb.specs.case_diameter_mm,
				strap_material = watchDb.specs.strap_material,
				water_resistance = watchDb.specs.water_resistance

			};
		}

		public IEnumerable<Watch> ToWatch(IEnumerable<WatchDb> watchesDb)
		{
			return watchesDb.Select(ToWatch);
		}

		public WatchDb ToWatchDb(Watch watch)
		{
			return new WatchDb()
			{
				Id = watch.id,
				name = watch.name,
				description = watch.description,
				price = watch.price,
				image = watch.image,
				Category = watch.category,
				filters = new Filters
				{
					strap = watch.strap,
					dial_color = watch.dial_color,
					case_material = watch.case_material
				},
				specs = new Specs
				{
					case_diameter_mm = watch.case_diameter_mm,
					strap_material = watch.strap_material,
					water_resistance = watch.water_resistance
				},


				//strap = watch.strap,
				//dial_color = watch.dial_color,
				//case_material = watch.case_material,
				//case_diameter_mm = watch.case_diameter_mm,
				//strap_material = watch.strap_material,
				//water_resistance = watch.water_resistance,
				DateCreated = DateTime.UtcNow.ToString()
			};
		}

		public IEnumerable<WatchDb> ToWatchDb(IEnumerable<Watch> watches)
		{
			return watches.Select(ToWatchDb);
		}

	}
}
