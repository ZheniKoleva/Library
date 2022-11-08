using Library.Data;
using System.ComponentModel.DataAnnotations;

namespace Library.Models.User
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        public string UserName { get; set; } = null!;

        [Required(ErrorMessage = DataConstants.ErrorMessages.RequiredMessage)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
    }
}
