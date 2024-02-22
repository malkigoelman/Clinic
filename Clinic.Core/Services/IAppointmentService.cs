using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Services
{
    public interface IAppointmentService
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetAppointmentAsync(int id);
        Task<IEnumerable<Appointment>> GetAppointmentsByClientIdAsync(int clientId);
        Task AddAppointmentAsync(Appointment appointment);
        Task RemoveAppointmentAsync(int id);
        Task UpdateAppointmentAsync(int id, Appointment appointment);


    }
}
