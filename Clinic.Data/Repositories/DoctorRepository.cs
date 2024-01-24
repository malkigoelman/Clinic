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

        public Doctor AddDoctor(Doctor doctor)
        {
            _dataContext.Doctors.Add(doctor);
            _dataContext.SaveChanges();
            return doctor;
        }

        public void DeleteDoctor(int id)
        {
            var doctor = GetDoctor(id);
            _dataContext.Doctors.Remove(doctor);
            _dataContext.SaveChanges();
        }

        public Doctor GetDoctor(int id)
        {
            return _dataContext.Doctors.Find(id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _dataContext.Doctors.Include(u => u.Shifts).Include(u => u.Specialization);
        }

        public Doctor UpdateDoctor(int id, Doctor doctor)
        {
            var doctor1 = GetDoctor(id);
            doctor1.Tz = doctor.Tz;
            doctor1.Name = doctor.Name;
            doctor1.Specialization = doctor.Specialization;
            doctor1.Birthday = doctor.Birthday;
            doctor1.Address = doctor.Address;
            doctor1.Phone = doctor.Phone;
            _dataContext.SaveChanges();
            return doctor1;
        }

        public IEnumerable<Shift> GetShifts(int id)
        {
            return _dataContext.Doctors.Find(id).Shifts;
        }
        public IEnumerable<Specialization> GetSpecializations(int id)
        {
            return _dataContext.Doctors.Find(id).Specialization;
        }
    }
}
