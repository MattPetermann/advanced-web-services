using System;
using System.Linq;

namespace Modas.Models
{
	public class Event
	{
		public int EventId { get; set; }
		public DateTime TimeStamp { get; set; }
		public bool Flagged { get; set; }
        private int locationId { get; set; }
		public int LocationId { get; set; }
	}
}