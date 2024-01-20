using System.ComponentModel.DataAnnotations.Schema;

namespace webApp.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly StartAt { get; set; }
        public TimeOnly EndAt { get; set; }
        public string Address { get; set; }
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
        public string Description { get; set; }
    }
}
