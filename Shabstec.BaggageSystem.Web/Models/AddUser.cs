using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Web.Models
{
    public class AddUser
    {
        public string id { get; set; } // 'id' property is required
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = "The Password field must be a minimum of 6 characters")]
        public string Password { get; set; }
    }
}