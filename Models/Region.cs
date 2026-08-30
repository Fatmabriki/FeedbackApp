using System.Collections.Generic;

namespace FeedbackApp.Models
{
    public class Region
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Wilaya> Wilayas { get; set; } = new List<Wilaya>();
    }
}
