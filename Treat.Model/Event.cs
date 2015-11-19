using System;
using System.Collections.Generic;

namespace Treat.Model
{
    public class Event
    {
        public long Id { get; set; }
        public User Host { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Slots { get; set; }
        public DateTime Start { get; set; }
        public DateTime? End { get; set; }
        public decimal Price { get; set; }
        public DateTime Created { get; set; }
        public Location Location { get; set; }
        public IList<Category> Categories { get; set; }
    }
}
