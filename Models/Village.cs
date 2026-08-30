namespace FeedbackApp.Models
{
    public class Village
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AreaId { get; set; }
        public Area Area { get; set; }
    }
}
