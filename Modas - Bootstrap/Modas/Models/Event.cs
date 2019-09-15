using System;
using System.Linq;

namespace Modas.Models
{
	public class Event
	{
		public Guid EventId { get; set; }
		public DateTime TimeStamp { get; set; }
		public bool Flagged { get; set; }
        private int locationId { get; set; }
		public int LocationId {
            get => locationId;
            set {
                locationId = value;
                Location = FakeEventRepository.Locations.Single(l => l.LocationId == value);
            }
        }
		public Location Location { get; set; }
	}
}