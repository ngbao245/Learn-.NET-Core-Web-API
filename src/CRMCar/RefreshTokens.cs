using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CRMCar.Entity;

namespace CRMCar
{
    public class RefreshTokens
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }
        public string? Token { get; set; }
        public DateTime? ExpireTime { get; set; }
        public bool isActive { get; set; }
    }
}
