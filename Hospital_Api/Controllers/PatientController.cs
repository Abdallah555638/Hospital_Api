using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hospital_Api.Dto;
using Hospital_Api.Model;
using Hospital_Api.Repo;

namespace Hospital_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenaric<Doctor> _doctorGenaric;
        private readonly PatientRepo _patientRepo;

        public PatientController(IMapper mapper, IGenaric<Doctor> doctorGenaric, PatientRepo patientRepo)
        {
            _mapper = mapper;
            _doctorGenaric = doctorGenaric;
            _patientRepo = patientRepo;
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient(AddPatientDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = _mapper.Map<Patient>(dto);

            if (dto.DoctorIds != null)
            {
                foreach (var item in dto.DoctorIds)
                {
                    var doctor = await _doctorGenaric.GetById(item);
                    if(doctor == null) 
                    {
                        return NotFound();
                    }
                    result.Doctors.Add(doctor);
                }
            }
            await _patientRepo.Add(result);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnPatientDto>>> GetAll()
        {
            var result = await _patientRepo.GetAll();
            var mapping = _mapper.Map<IEnumerable<ReturnPatientDto>>(result);
            return Ok(mapping);
        }

        [HttpDelete]
        public async Task<ActionResult> DeletePatient(int id)
        {
            var result = await _patientRepo.Delete(id);
            if (result == null) return NotFound();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> updatePatient(int id , AddPatientDto dto)
        {
            var result = await _patientRepo.GetById(id);
            if (result == null) return NotFound();

            result.Name = dto.Name;
            result.Email = dto.Email;

            if(dto.Medical_Device != null)
            {
                if(result.medical_device == null)
                {
                    result.medical_device = new Medical_Device();
                }

                result.medical_device.DeviceName = dto.Medical_Device.DeviceName;
                result.medical_device.Type = dto.Medical_Device.Type;
            }

            if (dto.DoctorIds != null)
            {
                result.Doctors.Clear();
                foreach (var item in dto.DoctorIds)
                {
                    var doctor = await _doctorGenaric.GetById(item);
                    if (doctor == null)
                    {
                        return NotFound();
                    }
                    result.Doctors.Add(doctor);
                }
            }
            await _patientRepo.Update(result);
            return Ok();


        }
    }

      
}
