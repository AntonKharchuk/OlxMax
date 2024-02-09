
using System.ComponentModel.DataAnnotations;

namespace OlxMax.Dal.Features.UserFeatures
{
    public class GetUserDto
    {
        public int Id { get; set; } 

        public double Balace { get; set; }

        public string? UserName { get; set; }
    }
    public class CreateUserDto
    {
        public double Balace { get; set; }

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
    public class UpdateUserDto
    {
        [Required]
        public int Id { get; set; }

        public double Balace { get; set; }

        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
