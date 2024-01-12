
using System.ComponentModel.DataAnnotations;

namespace CRUD.DTOs
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Class { get; set; } = string.Empty;
        public string? Nation { get; set; } = string.Empty;
    }
}
