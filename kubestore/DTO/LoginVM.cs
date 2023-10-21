using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kubestore.DTO
{
    public class LoginVM
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set;}

        [Required]
        [PasswordPropertyText]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set;}

        public LoginVM(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
