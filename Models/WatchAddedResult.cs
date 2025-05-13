using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
	public class WatchAddedResult
	{
		public long ID { get; set; }
		public string name { get; set; }
		public string message { get; set; } = "Server Assigns a new Id to the watch";
	}
}
