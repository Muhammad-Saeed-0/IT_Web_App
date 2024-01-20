using System.ComponentModel.DataAnnotations;

namespace webApp.Models
{
    public class StaffLink
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Link { get; set; }

        [Required]
        public int StaffId { get; set; }
        public Staff Staff { get; set; }

    }
}
