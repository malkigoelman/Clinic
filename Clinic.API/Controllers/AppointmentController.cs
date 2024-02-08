using AutoMapper;
using Clinic.API.Model;
using Clinic.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly IDoctorService _doctorService;
        private readonly IMapper _mapper;
        public AppointmentController(IAppointmentService appointmentService,IMapper mapper,IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;   
            _doctorService = doctorService;
        }

        // GET: api/<AppointmentController>
        [HttpGet]
        public ActionResult<IEnumerable<AppointmentDTO>> Get()
        {
            var list = _appointmentService.GetAppointments();
            var listDTO = list.Select(a => _mapper.Map<AppointmentDTO>(a));
            return Ok(listDTO);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("clients/{clientId}")]
        public ActionResult<IEnumerable<AppointmentDTO>>  GetByClient(int clientId)
        {
            var p= _appointmentService.GetAppointmentsByClientId(clientId);
            if (p.Count() == 0)
                NotFound();
            var pDTO = p.Select(a=>_mapper.Map<AppointmentDTO>(a));
            return Ok(pDTO);
        }
        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public ActionResult<AppointmentDTO> Get(int id)
        {
            var p = _appointmentService.GetAppointment(id);
            if (p == null)
                NotFound();
            var pDTO = _mapper.Map<AppointmentDTO>(p);
            return Ok(pDTO);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public ActionResult Post([FromBody] AppointmentPostModel appointment)
        {
            var appointmentToAdd = _mapper.Map<Appointment>(appointment);
            //לשלוף את הדוקטור
            //לשלוף את הלקוח
            //לשלוף את ההתמחות
            //לשייך את כל אלה לפגישה
            appointmentToAdd.Doctor = doctor;
            //var spec = _doctorService.GetSpecializations(appointmentToAdd.DoctorId).First(s => s.Id == appointment.TreatmentId);
            //if (spec == null)
            //    return NotFound();
            //appointmentToAdd.Treatment = spec;
            _appointmentService.AddAppointment(appointmentToAdd);
            return Ok(_mapper.Map<AppointmentDTO>(appointmentToAdd));
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Appointment appointment)
        {
            var appointment1 = _appointmentService.GetAppointment(id);
            if(appointment1==null)
                NotFound();
            _mapper.Map(appointment,appointment1);
            _appointmentService.UpdateAppointment(id, appointment1);
            return Ok(_mapper.Map<AppointmentDTO>(appointment1));
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
