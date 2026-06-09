using System.ComponentModel.DataAnnotations;

namespace MediCoreHMS.Web.Models.Auth;

public class LoginViewModel
{
    [Required(ErrorMessage = "Email required")]
    [EmailAddress(ErrorMessage = "Invalid email format")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;

    public bool RememberMe { get; set; }
    public string? ReturnUrl { get; set; }
}