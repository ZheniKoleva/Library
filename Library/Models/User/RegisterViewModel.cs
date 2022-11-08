using Library.Data;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.User
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [StringLength(DataConstants.User.UsernameMaxLength, MinimumLength = DataConstants.User.UsernameMinLength,
           ErrorMessage = DataConstants.ErrorMessages.GeneralMessage)]
        public string UserName { get; set; } = null!;


        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [EmailAddress]
        [StringLength(DataConstants.User.EmailMaxLength, MinimumLength = DataConstants.User.EmailMinLength,
            ErrorMessage = DataConstants.ErrorMessages.GeneralMessage)]
        public string Email { get; set; } = null!;


        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        [StringLength(DataConstants.User.PasswordMaxLength, MinimumLength = DataConstants.User.PasswordMinLength,
            ErrorMessage = DataConstants.ErrorMessages.GeneralMessage)]
        public string Password { get; set; } = null!;


        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [Compare(nameof(Password), ErrorMessage = DataConstants.ErrorMessages.CompareMessage)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; } = null!;
    }
}
