using Mirpaha.Clinic.Core.Repositories;
using Mirpaha.Entities;

namespace Mirpaha.Clinic.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DataContext _dataContext;
        public AppointmentRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public Appointment AddAppointment(Appointment appointment)
        {
            _dataContext.Appointments.Add(appointment);
            _dataContext.SaveChanges();
            return appointment;
        }

        public void DeleteAppointment(int id)
        {
            var appointment=GetAppointmentById(id);
            _dataContext.Appointments.Remove(appointment);
            _dataContext.SaveChanges();
        }

        public Appointment GetAppointmentById(int id)
        {
            return _dataContext.Appointments.Find(id);
        }

        public IEnumerable<Appointment> GetAppointments()
        {
            return _dataContext.Appointments.ToList();
        }

        public Appointment UpdateAppointment(int id, Appointment appointment)
        {
            var appointment1 = GetAppointmentById(id);
            appointment1.Treatment = appointment.Treatment;
            appointment1.Price=appointment.Price;
            appointment1.Date_Time = appointment.Date_Time;
            appointment1.Duration = appointment.Duration;
            appointment1.Room=appointment.Room;
            appointment1.ClientId=appointment.ClientId;
            appointment1.DoctorId=appointment.DoctorId;
            _dataContext.SaveChanges();
            return appointment1;
        }
    }
}
