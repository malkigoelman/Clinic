using Microsoft.AspNetCore.Mvc;
using Mirpaha.Clinic.Core.Services;
using Mirpaha.Entities;




// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mirpaha.Controllers
{
    [Route("clinic/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        // GET: api/<AppointmentController>
        [HttpGet]
        public ActionResult<IEnumerable<Appointment>> Get()
        {
            return Ok(_appointmentService.GetAppointments());
        }

        // GET api/<AppointmentController>/5
        [HttpGet("clients/{clientId}")]
        public ActionResult<IEnumerable<Appointment>>  GetByClient(int clientId)
        {
            List<Appointment> p= _appointmentService.GetAppointmentsByClientId(clientId).ToList();
            if (p.Count() == 0)
                NotFound();
            return Ok(p);
        }
        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public ActionResult<Appointment> Get(int id)
        {
            Appointment p = _appointmentService.GetAppointment(id);
            if (p == null)
                NotFound();
            return Ok(p);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public void Post([FromBody] Appointment appointment)
        {
            _appointmentService.AddAppointment(appointment);
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Appointment appointment)
        {
            Appointment appointment1 = _appointmentService.GetAppointment(id);
            if(appointment1==null)
                NotFound();
            _appointmentService.UpdateAppointment(id, appointment);
            return Ok();
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Appointment appointment1 = _appointmentService.GetAppointment(id);
            if (appointment1 == null)
                NotFound();
            _appointmentService.RemoveAppointment(id);
            return Ok();    
        }
    }
}
