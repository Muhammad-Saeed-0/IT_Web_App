using System.ComponentModel.DataAnnotations;

namespace webApp.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateOnly Date { get; set; }
        [Required]
        public string Description { get; set; }

        [Required]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }
    }
}
