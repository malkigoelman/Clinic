using Microsoft.EntityFrameworkCore;
using Mirpaha.Clinic.Core.Repositories;
using Mirpaha.Clinic.Core.Services;
using Mirpaha.Entities;

namespace Mirpaha.Clinic.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DataContext _dataContext;
        public DoctorRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
           await _dataContext.Doctors.AddAsync(doctor);
           await _dataContext.SaveChangesAsync();
            return doctor;
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var doctor =await GetDoctorAsync(id);
            _dataContext.Doctors.Remove(doctor);
          await  _dataContext.SaveChangesAsync();
        }

        public async Task<Doctor> GetDoctorAsync(int id)
        {
            return await _dataContext.Doctors.FindAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _dataContext.Doctors.Include(u => u.Shifts).Include(u => u.Specialization).ToListAsync();
        }

        public async Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor)
        {
            var doctor1 =await GetDoctorAsync(id);
            doctor1.TzNumber = doctor.TzNumber;
            doctor1.Name = doctor.Name;
            doctor1.Specialization = doctor.Specialization;
            doctor1.Birthday = doctor.Birthday;
            doctor1.Address = doctor.Address;
            doctor1.Phone = doctor.Phone;
          await  _dataContext.SaveChangesAsync();
            return doctor1;
        }

        public async Task<IEnumerable<Shift>> GetShiftsAsync(int id)
        {
            return  _dataContext.Doctors.FindAsync(id).Result.Shifts;
        }
        public async Task<IEnumerable<Specialization>> GetSpecializationsAsync(int id)
        {
            return await _dataContext.Specialization.ToListAsync();//.Where(s => s.Doctor.Id == id);
        }
    }
}
