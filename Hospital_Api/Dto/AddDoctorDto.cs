using System.ComponentModel.DataAnnotations;

namespace Hospital_Api.Dto
{
    public class AddDoctorDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public string? Phone { get; set; }

        public int DepartmentId { get; set; }
    }
}
