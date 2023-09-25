using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CRMCar.Models
{
    public class CarModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal? Price { get; set; }
        public DateTime? ExpireDate { get; set; }
        public bool? IsActive { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public int UserId { get; set; }
    }
}
