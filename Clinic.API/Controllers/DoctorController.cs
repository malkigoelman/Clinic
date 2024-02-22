using AutoMapper;
using Clinic.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Mirpaha.Clinic.Core.Services;
using Mirpaha.Entities;
using System.Drawing;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirpaha.Controllers
{
    [Route("clinic/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorService doctorService,IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        // GET: api/<DoctorController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> Get()
        {
            var list=await _doctorService.GetDoctorsAsync();
            //var listdto = _mapper.Map<IEnumerable<DoctorDTO>>(list);
            var listdto = list.Select(d => _mapper.Map<DoctorDTO>(d));
            return Ok(listdto);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{code}")]
        public async Task<ActionResult<DoctorDTO>> Get(int code)
        {
            var d =await _doctorService.GetDoctorAsync(code);
            if (d == null)
                NotFound();
            var ddto=_mapper.Map<DoctorDTO>(d);
            return Ok(ddto);
        }
        [HttpGet("{code}/specialization")]
        public async Task<ActionResult<IEnumerable<Specialization>>> GetSpacialization(int code)
        {
            Doctor doctor1 =await _doctorService.GetDoctorAsync(code);
            if(doctor1 == null || doctor1.Specialization == null)
                return NotFound();
            return Ok(await _doctorService.GetSpecializationsAsync(code));
        }
        // POST api/<DoctorController>
        [HttpPost]
        public async Task<ActionResult<DoctorDTO>> Post([FromBody] DoctorDTO doctor)
        {
            var doctor1=_mapper.Map<Doctor>(doctor);
           await _doctorService.AddDoctorAsync(doctor1);
            return Ok(doctor);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{code}")]
        public async Task<ActionResult<DoctorDTO>> Put(int code, [FromBody] DoctorDTO doctor)
        {
            var doctor1 =await _doctorService.GetDoctorAsync(code);
            if (doctor1 == null)
                NotFound();
            _mapper.Map(doctor,doctor1);
          await  _doctorService.UpdateDoctorAsync(code, doctor1);
            return Ok(doctor1);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{code}")]
        public async Task<ActionResult> Delete(int code)
        {
            Doctor doctor1 =await _doctorService.GetDoctorAsync(code);
            if (doctor1 == null)
                NotFound();
          await  _doctorService.RemoveDoctorAsync(code);
            return Ok();
        }
        [HttpGet("{code}/shifts")]
        public async Task<ActionResult<IEnumerable<Shift>>> GetShifts(int code)
        {
            Doctor doctor1 = await _doctorService.GetDoctorAsync(code);
            if(doctor1 == null)
                return NotFound();
            return Ok( await _doctorService.GetShiftsAsync(code));
        }
    }
}
