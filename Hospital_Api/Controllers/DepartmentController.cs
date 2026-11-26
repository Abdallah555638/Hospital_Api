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
    public class DepartmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenaric<Department> _departmentGenaric;

        public DepartmentController(IMapper mapper, IGenaric<Department> departmentGenaric)
        {
            _mapper = mapper;
            _departmentGenaric = departmentGenaric;
        }

        [HttpPost]

        public async Task<ActionResult> Add(AddDepartmentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _mapper.Map<Department>(dto);
            await _departmentGenaric.Add(result);
            return Ok();
        }
    }
}
