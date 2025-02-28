using System.ComponentModel.DataAnnotations;

namespace CCNLTHD_Dotnet.Data.Entities
{
    public class TodoList
    {
        [Key]
        public int Id { get; set; }

        public bool? Status { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
