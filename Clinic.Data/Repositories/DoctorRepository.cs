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
            return _dataContext.Doctors.ToList();
        }

        public Doctor UpdateDoctor(int id, Doctor doctor)
        {
            var doctor1 = GetDoctor(id);
            doctor1.DoctorId = doctor.DoctorId;
            doctor1.Name = doctor.Name;
            doctor1.specialization = doctor.specialization;
            doctor1.Birthday = doctor.Birthday;
            doctor1.Address = doctor.Address;
            doctor1.Phone = doctor.Phone;
            _dataContext.SaveChanges();
            return doctor1;
            //doctor1 = doctor;
            //_dataContext.SaveChanges();
            //return doctor1;
            //DeleteDoctor(id);
            //return AddDoctor(doctor);
            //_dataContext.SaveChanges();
            //_dataContext.Doctors.Update(doctor);
            //_dataContext.SaveChanges();
            //return doctor;
        }
    }
}
