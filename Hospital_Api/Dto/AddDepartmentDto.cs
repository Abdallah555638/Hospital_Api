using System.ComponentModel.DataAnnotations;

namespace Hospital_Api.Dto
{
    public class AddDepartmentDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
