using System.Collections.Generic;

namespace FeedbackApp.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int WilayaId { get; set; }
        public Wilaya Wilaya { get; set; }

        public List<Village> Villages { get; set; } = new List<Village>();
    }
}
