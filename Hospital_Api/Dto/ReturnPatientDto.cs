using Hospital_Api.Model;

namespace Hospital_Api.Dto
{
    public class ReturnPatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<DoctorReturnPatientDto>? Doctors { get; set; } = new List<DoctorReturnPatientDto>();
        public Medical_DeviceInReturnPatientDto? medical_device { get; set; }
    }

    public class DoctorReturnPatientDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Medical_DeviceInReturnPatientDto
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string Type { get; set; }
    }
}
