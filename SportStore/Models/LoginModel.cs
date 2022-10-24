using System.ComponentModel.DataAnnotations;

namespace SportStore.Models
{
    public class LoginModel
    {

        public string Name { get; set; }

        public string LastName { get; set; }
        [Required(ErrorMessage ="Email is required")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password is required")]
        [UIHint("password")]
        public string Password { get; set; }
        //public string ReturnUrl { get; set; } = "/";
    }
}
