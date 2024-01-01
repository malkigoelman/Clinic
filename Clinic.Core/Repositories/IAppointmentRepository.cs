using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointmentById(int id); 
        void AddAppointment(Appointment appointment);
        void UpdateAppointment(int id,Appointment appointment);
        void DeleteAppointment(int id);
    }
}
