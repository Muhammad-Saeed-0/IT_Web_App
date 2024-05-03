using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApp.Models
{
    public class Gallery
    {
        [Key]
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
