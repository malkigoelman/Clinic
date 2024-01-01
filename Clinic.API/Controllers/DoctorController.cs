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
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        // GET: api/<DoctorController>
        [HttpGet]
        public ActionResult<IEnumerable<Doctor>> Get()
        {
            return Ok(_doctorService.GetDoctors());
        }

        // GET api/<DoctorController>/5
        [HttpGet("{code}")]
        public ActionResult<Doctor> Get(int code)
        {
            Doctor d = _doctorService.GetDoctor(code);
            if (d == null)
                NotFound();
            return Ok(d);
        }
        [HttpGet("{code}/specialization")]
        public ActionResult<Specialization> GetSpecialization(int code)
        {
            Doctor d = _doctorService.GetDoctor(code);
            return d.specialization;
        }

        // POST api/<DoctorController>
        [HttpPost]
        public void Post([FromBody] Doctor doctor)
        {
            _doctorService.AddDoctor(doctor);
        }

        // PUT api/<DoctorController>/5
        [HttpPut("{code}")]
        public ActionResult Put(int code, [FromBody] Doctor doctor)
        {
            Doctor doctor1 = _doctorService.GetDoctor(code);
            if (doctor1 == null)
                NotFound();
            _doctorService.UpdateDoctor(code, doctor);
            return Ok();
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
    }
}
