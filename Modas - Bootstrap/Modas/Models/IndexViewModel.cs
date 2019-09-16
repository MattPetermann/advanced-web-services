using System.Collections.Generic;

namespace Modas.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public int EventCount { get; set; }
        public int MaxPages { get; set; }
        public int CurrentPage { get; set; }
        public int ResultCount { get; set; }
    }
}
