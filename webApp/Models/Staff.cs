using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApp.Models
{
    public class Staff
    {
        [Key]
        public int Id { get; set; }
        //[MaxLength(100)]
        //[DisplayName("")]
        //[Range(0, 100, ErrorMessage = " ")]
        [Required]
        public string Name { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public string Degree { get; set; }
        [Required]
        public string Major { get; set; }
        [DisplayName("More Information")]
        public string PersonalInfo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [DisplayName("Personal Image")]
        public string PersonalImgUrl { get; set; }
        [NotMapped]
        public IFormFile UserImage { get; set; }

        public ICollection<Education> Educations { get; set; }
        public ICollection<ScientificAchievement> ScientificAchievements { get; set; }
        public ICollection<StaffLink> StaffLinks { get; set; }
    }
}
