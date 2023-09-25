using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMCar.Entity
{
    [Table("User")]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string? VerificationToken { get; set; }
        public string Email { get; set; }
        public string? resetToken { get; set; }
        public DateTime ResetTokenExpire { get; set; }
        public bool? IsActive { get; set; }
        ICollection<Car> Cars { get; set; }

        public ICollection<RefreshTokens> RefreshTokens { get; set; }

    }
}
