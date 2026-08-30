using System.Collections.Generic;

namespace FeedbackApp.Models
{
    public class Wilaya
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int RegionId { get; set; }
        public Region Region { get; set; }

        public List<Area> Areas { get; set; } = new List<Area>();
    }
}
