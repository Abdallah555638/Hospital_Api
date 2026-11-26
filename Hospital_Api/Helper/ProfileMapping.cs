using AutoMapper;
using Hospital_Api.Dto;
using Hospital_Api.Model;

namespace Hospital_Api.Helper
{
    public class ProfileMapping : Profile
    {
        public ProfileMapping()
        {
            //add
            CreateMap<AddDepartmentDto, Department>();
            CreateMap<AddPatientDto, Patient>();
            CreateMap<Medical_DeviceInAddPatientDto, Medical_Device>();
            CreateMap<AddDoctorDto, Doctor>();

            //Return
            CreateMap<Patient, ReturnPatientDto>();
            CreateMap<Doctor, DoctorReturnPatientDto>();
            CreateMap<Medical_Device, Medical_DeviceInReturnPatientDto>();
            CreateMap<Doctor, ReturnDoctorDto>();
            CreateMap<Department, DepartmentInReturnDoctorDto>();
        }

    }
}
