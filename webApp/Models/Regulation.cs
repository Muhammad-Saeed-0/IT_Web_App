using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApp.Models
{
    public class Regulation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }
        public string Title { get; set; }
        public DateOnly Date { get; set; }
        public string Details { get; set; }

        public ICollection<Requirement> Requirements { get; set; }
    }
}
