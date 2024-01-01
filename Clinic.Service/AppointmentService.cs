using Mirpaha.Clinic.Core.Repositories;
using Mirpaha.Clinic.Core.Services;
using Mirpaha.Entities;

namespace Mirpaha.Clinic.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        public AppointmentService(IAppointmentRepository appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }
        public void AddAppointment(Appointment appointment)
        {
            _appointmentRepository.AddAppointment(appointment);
        }

        public Appointment GetAppointment(int id)
        {
            return _appointmentRepository.GetAppointmentById(id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _appointmentRepository.GetAppointments();
        }

        public IEnumerable<Appointment> GetAppointmentsByClientId(int clientId)
        {
            return GetAppointments().ToList().FindAll(a => a.ClientId == clientId);
        }

        public void RemoveAppointment(int id)
        {
            _appointmentRepository.DeleteAppointment(id);
        }

        public void UpdateAppointment(int id, Appointment appointment)
        {
            _appointmentRepository.UpdateAppointment(id, appointment);
        }
    }
}
