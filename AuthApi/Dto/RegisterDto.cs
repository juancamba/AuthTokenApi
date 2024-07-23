using System.ComponentModel.DataAnnotations;

namespace AuthApi.Dto
{
    public class RegisterDto
    {
        [Required]
        public string Username { get; set; }


        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}

