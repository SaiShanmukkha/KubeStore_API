using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace kubestore.DTO
{
    public class RegisterVM
    {
        [Required]
        [EmailAddress]
        [StringLength(50)]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }
        [Required]
        [PasswordPropertyText]
        [StringLength(20, MinimumLength = 8)]
        public string ConfirmPassword { get; set; }

        public RegisterVM(string email, string password, string confirmPassword)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
        }
    }
}
