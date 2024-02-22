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
        public async Task AddAppointmentAsync(Appointment appointment)
        {
           await  _appointmentRepository.AddAppointmentAsync(appointment);
        }

        public async Task<Appointment> GetAppointmentAsync(int id)
        {
            return await _appointmentRepository.GetAppointmentByIdAsync(id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await _appointmentRepository.GetAppointmentsAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsByClientIdAsync(int clientId)
        {
            return  GetAppointmentsAsync().Result.ToList().FindAll(a => a.ClientId == clientId);
        }

        public async Task RemoveAppointmentAsync(int id)
        {
          await  _appointmentRepository.DeleteAppointmentAsync(id);
        }

        public async Task UpdateAppointmentAsync(int id, Appointment appointment)
        {
           await _appointmentRepository.UpdateAppointmentAsync(id, appointment);
        }
    }
}
