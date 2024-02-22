using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Repositories
{
    public interface IAppointmentRepository
    {
        Task<IEnumerable<Appointment>> GetAppointmentsAsync();
        Task<Appointment> GetAppointmentByIdAsync(int id);
        Task<Appointment> AddAppointmentAsync(Appointment appointment);
        Task<Appointment> UpdateAppointmentAsync(int id, Appointment appointment);
        Task DeleteAppointmentAsync(int id);
    }
}
