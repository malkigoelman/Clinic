using Microsoft.EntityFrameworkCore;
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

        public async Task<Appointment> AddAppointmentAsync(Appointment appointment)
        {
            _dataContext.Appointments.Add(appointment);
           await _dataContext.SaveChangesAsync();
            return appointment;
        }

        public async Task DeleteAppointmentAsync(int id)
        {
            var appointment=await GetAppointmentByIdAsync(id);
            _dataContext.Appointments.Remove(appointment);
           await _dataContext.SaveChangesAsync();
        }

        public async Task<Appointment> GetAppointmentByIdAsync(int id)
        {
            return await _dataContext.Appointments.FindAsync(id);
        }

        public async Task<IEnumerable<Appointment>> GetAppointmentsAsync()
        {
            return await _dataContext.Appointments.Include(u => u.Doctor).Include(u=>u.Client).ToListAsync();
        }

        public async Task<Appointment> UpdateAppointmentAsync(int id, Appointment appointment)
        {
            var appointment1 =await GetAppointmentByIdAsync(id);
            appointment1.Treatment = appointment.Treatment;
            appointment1.Price=appointment.Price;
            appointment1.Date_Time = appointment.Date_Time;
            appointment1.Duration = appointment.Duration;
            appointment1.Room=appointment.Room;
            appointment1.ClientId=appointment.ClientId;
            appointment1.DoctorId=appointment.DoctorId;
           await _dataContext.SaveChangesAsync();
            return appointment1;
        }
    }
}
