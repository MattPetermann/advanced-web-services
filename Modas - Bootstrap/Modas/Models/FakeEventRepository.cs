using System;
using System.Collections.Generic;
using System.Linq;

namespace Modas.Models
{
	public class FakeEventRepository
	{
        public static IEnumerable<Location> Locations => new List<Location>
        {
            new Location { LocationId = 0, Name = "Front door" },
            new Location { LocationId = 1, Name = "Back door" },
            new Location { LocationId = 2, Name = "Office" }
        };

        private static List<Event> _events;
		public static List<Event> Events {
            get {
                //If events does not exist, create it
                if(_events == null)
                {
                    //Initialize events
                    _events = new List<Event>();

                    //Count days in past six months
                    var dayCount = DateTime.UtcNow.Subtract(DateTime.UtcNow.AddMonths(-6)).Days;

                    //For each day in the past six months
                    for(var i = 0; i < dayCount; i++)
                    {
                        //Find target day
                        var previousDay = DateTime.UtcNow.AddDays(-i);

                        //Generate 0-5 events
                        var numberOfEvents = new Random().Next(6);

                        //For each event
                        for (var j = 0; j < numberOfEvents; j++)
                        {
                            //Add a new event
                            _events.Add(new Event
                            {
                                TimeStamp = new DateTime(previousDay.Year, previousDay.Month, previousDay.Day,
                                new Random().Next(24), new Random().Next(60), new Random().Next(60)),
                                Flagged = false,
                                LocationId = new Random().Next(Locations.Count())
                            });
                        }
                    }

                    //Reorder list by date
                    _events = _events.OrderBy(e => e.TimeStamp).ToList();
                }

                //Return private instsance
                return _events;
            }
            
            set => _events = value;
        }
	}
}