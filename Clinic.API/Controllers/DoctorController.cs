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
        public ActionResult<IEnumerable<DoctorDTO>> Get()
        {
            var list=_doctorService.GetDoctors();
            var listdto = _mapper.Map<IEnumerable<DoctorDTO>>(list);
            return Ok(listdto);
        }

        // GET api/<DoctorController>/5
        [HttpGet("{code}")]
        public ActionResult<DoctorDTO> Get(int code)
        {
            var d = _doctorService.GetDoctor(code);
            if (d == null)
                NotFound();
            var ddto=_mapper.Map<DoctorDTO>(d);
            return Ok(ddto);
        }
        [HttpGet("{code}/specialization")]
        public ActionResult<IEnumerable<Specialization>> GetSpacialization(int code)
        {
            Doctor doctor1 = _doctorService.GetDoctor(code);
            if(doctor1 == null)
                return NotFound();
            return Ok(_doctorService.GetSpecializations(code));
        }
        // POST api/<DoctorController>
        [HttpPost]
        public ActionResult<DoctorDTO> Post([FromBody] DoctorDTO doctor)
        {
            var doctor1=_mapper.Map<Doctor>(doctor);
            _doctorService.AddDoctor(doctor1);
            return Ok(doctor);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{code}")]
        public ActionResult<DoctorDTO> Put(int code, [FromBody] DoctorDTO doctor)
        {
            var doctor1 = _doctorService.GetDoctor(code);
            if (doctor1 == null)
                NotFound();
            _mapper.Map(doctor,doctor1);
            _doctorService.UpdateDoctor(code, doctor1);
            return Ok(doctor1);
        }

        // DELETE api/<DoctorController>/5
        [HttpDelete("{code}")]
        public ActionResult Delete(int code)
        {
            Doctor doctor1 = _doctorService.GetDoctor(code);
            if (doctor1 == null)
                NotFound();
            _doctorService.RemoveDoctor(code);
            return Ok();
        }
        [HttpGet("{code}/shifts")]
        public ActionResult<IEnumerable<Shift>> GetShifts(int code)
        {
            Doctor doctor1 = _doctorService.GetDoctor(code);
            if(doctor1 == null)
                return NotFound();
            return Ok(_doctorService.GetShifts(code));
        }
    }
}
