using System.ComponentModel.DataAnnotations;

namespace LawPavillion.Library.Backend.API.Dtos
{
    /// <summary>
    /// DTO for user login. Used in POST /api/auth/login.
    /// </summary>
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
