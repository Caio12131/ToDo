using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsAdmin { get; set; } = false;
    }
}