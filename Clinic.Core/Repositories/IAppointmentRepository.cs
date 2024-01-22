using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Repositories
{
    public interface IAppointmentRepository
    {
        IEnumerable<Appointment> GetAppointments();
        Appointment GetAppointmentById(int id); 
        Appointment AddAppointment(Appointment appointment);
        Appointment UpdateAppointment(int id,Appointment appointment);
        void DeleteAppointment(int id);
    }
}
