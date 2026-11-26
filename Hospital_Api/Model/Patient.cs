namespace Hospital_Api.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public ICollection<Doctor>? Doctors { get; set; } = new List<Doctor>();
        public Medical_Device? medical_device { get; set; }

    }
}
