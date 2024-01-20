using System.ComponentModel.DataAnnotations.Schema;

namespace webApp.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public string Details { get; set; }
        public bool IsActive { get; set; }
        public string MainImageUrl { get; set; }
        [NotMapped]
        public IFormFile MainImage { get; set; }
        [NotMapped]
        public ICollection<IFormFile> Images { get; set; }

        public ICollection<NewsImages> NewsImages { get; set; }
    }
}
