using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Services
{
    public interface IAppointmentService
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointment(int id);
        IEnumerable<Appointment> GetAppointmentsByClientId(int clientId);
        void AddAppointment(Appointment appointment);
        void RemoveAppointment(int id);
        void UpdateAppointment(int id, Appointment appointment);


    }
}
