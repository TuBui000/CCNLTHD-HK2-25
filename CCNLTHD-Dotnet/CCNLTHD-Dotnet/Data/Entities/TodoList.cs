using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CCNLTHD_Dotnet.Data.Entities
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }

        [Required]
        public string Title { get; set; }

  
        public DateTime Date { get; set; }
 
    }
}
