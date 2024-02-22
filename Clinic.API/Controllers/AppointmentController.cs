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
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public AppointmentController(IAppointmentService appointmentService, IMapper mapper, IDoctorService doctorService, IClientService clientService)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
            _doctorService = doctorService;
            _clientService = clientService;
        }

        // GET: api/<AppointmentController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAsync()
        {
            var list =await _appointmentService.GetAppointmentsAsync();
            var listDTO = list.Select(a => _mapper.Map<AppointmentDTO>(a));
            return Ok(listDTO);
        }

        // GET api/<AppointmentController>/5
        [HttpGet("clients/{clientId}")]
        public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetByClientAsync(int clientId)
        {
            var p = await _appointmentService.GetAppointmentsByClientIdAsync(clientId);
            if (p.Count() == 0)
                NotFound();
            var pDTO = p.Select(a => _mapper.Map<AppointmentDTO>(a));
            return Ok(pDTO);
        }
        // GET api/<AppointmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AppointmentDTO>> GetAsync(int id)
        {
            var p =await _appointmentService.GetAppointmentAsync(id);
            if (p == null)
                NotFound();
            var pDTO = _mapper.Map<AppointmentDTO>(p);
            return Ok(pDTO);
        }

        // POST api/<AppointmentController>
        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] AppointmentPostModel appointment)
        {
            var appointmentToAdd = _mapper.Map<Appointment>(appointment);
            appointmentToAdd.Doctor =await _doctorService.GetDoctorAsync(appointment.DoctorId);
            appointmentToAdd.Client =await _clientService.GetClientByIdAsync(appointment.ClientId);
            //appointmentToAdd.Treatment = appointmentToAdd.Doctor.Specialization.Find(s => s.Id == appointment.TreatmentId);
            appointmentToAdd.Treatment = _doctorService.GetSpecializationsAsync(appointment.DoctorId).Result.ToList().Find(s => s.Id == appointment.TreatmentId);
            if (appointmentToAdd.Treatment == null || appointmentToAdd.Client == null || appointmentToAdd.Doctor == null)
                return NotFound();            
           await _appointmentService.AddAppointmentAsync(appointmentToAdd);
            return Ok(_mapper.Map<AppointmentDTO>(appointmentToAdd));
        }

        // PUT api/<AppointmentController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> PutAsync(int id, [FromBody] Appointment appointment)
        {
            var appointment1 =await _appointmentService.GetAppointmentAsync(id);
            if (appointment1 == null)
                NotFound();
            _mapper.Map(appointment, appointment1);
           await _appointmentService.UpdateAppointmentAsync(id, appointment1);
            return Ok(_mapper.Map<AppointmentDTO>(appointment1));
        }

        // DELETE api/<AppointmentController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            Appointment appointment1 =await _appointmentService.GetAppointmentAsync(id);
            if (appointment1 == null)
                NotFound();
            await _appointmentService.RemoveAppointmentAsync(id);
            return Ok();
        }
    }
}
