using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace webApp.Models
{
    public class Regulation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string Code { get; set; }
        public string Title { get; set; }
        public string Hours { get; set; }
        //public string Program { get; set; }
        //public string Department { get; set; }

        public ICollection<Requirement> Requirements { get; set; }
    }
}
