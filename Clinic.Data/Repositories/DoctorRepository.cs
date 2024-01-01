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

        public void AddDoctor(Doctor doctor)
        {
            _dataContext.Doctors.Add(doctor);
        }

        public void DeleteDoctor(int id)
        {
            _dataContext.Doctors.Remove(GetDoctor(id));
        }

        public Doctor GetDoctor(int id)
        {
            return _dataContext.Doctors.ToList().Find(d => d.Id == id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
           return _dataContext.Doctors.ToList();
        }

        public void UpdateDoctor(int id,Doctor doctor)
        {
            DeleteDoctor(id);
            AddDoctor(doctor);
        }
    }
}
