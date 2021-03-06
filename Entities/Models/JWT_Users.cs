using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class JWT_Users
    {
        public int Id { get; set; }

        [EmailAddress(ErrorMessage = "Неправильный email")]
        public string Email { get; set; } = "";

        [Required]
        public string Password { get; set; } = "";
    }
}
