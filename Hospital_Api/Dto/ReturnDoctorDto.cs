using Hospital_Api.Model;

namespace Hospital_Api.Dto
{
    public class ReturnDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentInReturnDoctorDto? Department { get; set; }
    }

    public class DepartmentInReturnDoctorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
