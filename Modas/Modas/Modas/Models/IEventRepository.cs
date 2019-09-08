using System.Collections.Generic;
namespace Modas.Models
{
	public interface IEventRepository
	{
		IEnumerable<Event> Events { get; }
		IEnumerable<Location> Locations { get; }
	}
}