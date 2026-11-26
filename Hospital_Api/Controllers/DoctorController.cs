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
    public class DoctorController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenaric<Doctor> _doctorGenaric;
        private readonly IGenaric<Department> _departmentGenaric;
        private readonly DoctorRepo _doctorRepo;

        public DoctorController(IMapper mapper, IGenaric<Doctor> doctorGenaric, IGenaric<Department> departmentGenaric, DoctorRepo doctorRepo)
        {
            _mapper = mapper;
            _doctorGenaric = doctorGenaric;
            _departmentGenaric = departmentGenaric;
            _doctorRepo = doctorRepo;
        }

        [HttpPost]
        public async Task<ActionResult> AddDoctor(AddDoctorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _departmentGenaric.GetById(dto.DepartmentId);
            if(result == null)
            {
                return NotFound();
            }

            var result_mapping = _mapper.Map<Doctor>(dto);
            await _doctorGenaric.Add(result_mapping);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnDoctorDto>> GetById(int id)
        {
            var result = await _doctorRepo.GetById(id);
            if (result == null)
                return NotFound();
            var result_map = _mapper.Map<ReturnDoctorDto>(result);
            return Ok(result_map);
        }
    }
}
