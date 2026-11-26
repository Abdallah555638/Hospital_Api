using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http.HttpResults;


namespace Hospital_Api.Dto
{
    public class AddPatientDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public List<int>? DoctorIds { get; set; } = new List<int>();
        public Medical_DeviceInAddPatientDto? Medical_Device { get; set; }

    }

    public class Medical_DeviceInAddPatientDto
    {
        public string DeviceName { get; set; }
        public string Type { get; set; }
    }


    }
