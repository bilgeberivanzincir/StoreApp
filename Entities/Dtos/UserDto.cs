using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Entities.Dtos
{
    public record UserDto 
    {
        [DataType(DataType.Text)]
        [Required(ErrorMessage ="Username is required.")]
        public String? UserName { get; init; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage ="Email is required.")]
        public String? Email { get; init; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage ="PhoneNumber is required.")]
        public String? PhoneNumber { get; init; }

        public HashSet<String> Roles { get; set; } = new HashSet<string>();

    }
}