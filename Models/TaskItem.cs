using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool IsCompleted { get; set; }

        public int UserId { get; set; }
    }
}