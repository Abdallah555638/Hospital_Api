namespace Hospital_Api.Model
{
    public class Medical_Device
    {
        public int Id { get; set; }
        public string DeviceName { get; set; }
        public string Type { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
    }
}
