using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.DatabaseModels
{

	//public class WatchDb
	//{
	//	public int Id { get; set; }


	//	public string name { get; set; }
	//	public string description { get; set; }
	//	public int price { get; set; }
	//	public string image { get; set; }
	//	public string[] tags { get; set; }
	//	public string DataCreated { get; set; }
	//	public string strap { get; set; }
	//	public string dial_color { get; set; }
	//	public string case_material { get; set; }
	//	public int case_diameter_mm { get; set; }
	//	public string strap_material { get; set; }
	//	public string water_resistance { get; set; }

	//}

	[DynamoDBTable("Solun")]
	public class WatchDb
	{
		[DynamoDBHashKey]
		public int Id { get; set; }
		[DynamoDBRangeKey]
		public string Category { get; set; }
		public string name { get; set; }
		public string description { get; set; }
		public int price { get; set; }
		public string image { get; set; }
		public string[] tags { get; set; }
		public Filters filters { get; set; }
		public Specs specs { get; set; }
		public string DateCreated { get; set; }
	}

	public class Filters
	{
		public string strap { get; set; }
		public string dial_color { get; set; }
		public string case_material { get; set; }
	}

	public class Specs
	{
		public int case_diameter_mm { get; set; }
		public string strap_material { get; set; }
		public string water_resistance { get; set; }
	}

}
