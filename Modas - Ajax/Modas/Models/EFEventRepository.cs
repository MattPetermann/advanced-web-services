using System.Linq;

namespace Modas.Models
{
    public class EFEventRepository
    {
        private ApplicationDbContext context;

        public EFEventRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Event> Events => context.Events;
        public IQueryable<Location> Locations => context.Locations;
    }
}