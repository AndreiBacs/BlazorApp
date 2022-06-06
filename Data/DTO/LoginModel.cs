using System.ComponentModel.DataAnnotations;

namespace BlazorApp.Data.DTO
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
