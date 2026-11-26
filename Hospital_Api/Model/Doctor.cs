namespace Hospital_Api.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Patient>? Patients { get; set; } = new List<Patient>();

    }
}
