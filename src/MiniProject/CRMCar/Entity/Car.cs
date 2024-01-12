using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRMCar.Entity
{
    [Table("Car")]
    public class Car
    {
        [Key]
        public int Id { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }
        public string Brand { get; set; }
        [Column("decimal(18,7)")]
        [Range(0, int.MaxValue)]
        public decimal? Price { get; set; }
        [Column("date")]
        public DateTime? ExpireDate { get; set; }
        [DefaultValue(false)]
        public bool? IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }

    }
}
