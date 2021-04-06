using System.ComponentModel.DataAnnotations;

namespace Ermolaeva.Diploma.Web.Models
{
    public class ToDoList
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
