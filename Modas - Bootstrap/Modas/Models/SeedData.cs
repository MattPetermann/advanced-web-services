using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Modas.Models
{
    // static class cannot be instantiated
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            var Locations = new List<Location>();

            if (!context.Locations.Any())
            {
                Locations.Add(new Location { LocationId = 0, Name = "Front Door" });
                Locations.Add(new Location { LocationId = 1, Name = "Office" });
                Locations.Add(new Location { LocationId = 2, Name = "Back Door" });
                // first, add Locations
                foreach (var l in Locations)
                {
                    context.Locations.Add(l);
                    context.SaveChanges();
                }
            }

            if (!context.Events.Any())
            {
                //Initialize events
                var events = new List<Event>();

                //Count days in past six months
                var dayCount = DateTime.UtcNow.Subtract(DateTime.UtcNow.AddMonths(-6)).Days;

                //Count ids
                var id = 0;

                //For each day in the past six months
                for (var i = 0; i < dayCount; i++)
                {
                    //Find target day
                    var previousDay = DateTime.UtcNow.AddDays(-i);

                    //Generate 0-5 events
                    var numberOfEvents = new Random().Next(6);

                    //For each event
                    for (var j = 0; j < numberOfEvents; j++)
                    {
                        //Add a new event
                        events.Add(new Event
                        {
                            EventId = id,
                            TimeStamp = new DateTime(previousDay.Year, previousDay.Month, previousDay.Day,
                                new Random().Next(24), new Random().Next(60), new Random().Next(60)),
                            Flagged = false,
                            LocationId = new Random().Next(Locations.Count())
                        });

                        //Increment id
                        id++;
                    }
                }

                //Store list by date
                foreach (var e in events.OrderBy(e => e.TimeStamp).ToList())
                {
                    context.Events.Add(e);
                    context.SaveChanges();
                }
            }
        }
    }
}