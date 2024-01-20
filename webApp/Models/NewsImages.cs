using System.ComponentModel.DataAnnotations.Schema;

namespace webApp.Models
{
    public class NewsImages
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

        public int NewsId { get; set; }
        public News News { get; set; }
    }
}
