using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApp.Models
{
    public class Research
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Author { get; set; }
        public string CoAuthor { get; set; }
        [Required]
        public string Supervisors { get; set; }
        [Required]
        [DisplayName("Date Of Publication")]
        public DateOnly DateOfPublication { get; set; }
        [Required]
        public string Abstract { get; set; }
        //[Required]
        [DisplayName("PDF")]
        public string PdfUrl { get; set; }
        [NotMapped]
        public IFormFile PDF { get; set; }

    }
}
