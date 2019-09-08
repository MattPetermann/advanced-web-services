using System.Collections.Generic;

namespace Modas.Models
{
	public class FakeEventRepository : IEventRepository
	{
        public IEnumerable<Location> Locations => new List<Location>
        {
            new Location { LocationId = 0, Name = "Front door" },
            new Location { LocationId = 1, Name = "Back door" },
            new Location { LocationId = 2, Name = "Office" }
        };

        public IEnumerable<Event> _events;
		public IEnumerable<Event> Events {
            get {
                if(_events == null)
                {
                    _events = new List<Event>();
                }

                return _events;
            }
            
            set {
                _events = value;
            }
        }
	}
}