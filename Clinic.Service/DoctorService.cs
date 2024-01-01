using Mirpaha.Clinic.Core.Repositories;
using Mirpaha.Clinic.Core.Services;
using Mirpaha.Entities;

namespace Mirpaha.Clinic.Service
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;
        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public void AddDoctor(Doctor doctor)
        {
            _doctorRepository.AddDoctor(doctor);
        }

        public Doctor GetDoctor(int id)
        {
           return _doctorRepository.GetDoctor(id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctorRepository.GetDoctors();
        }

        public Specialization GetSpecializations(int doctorId)
        {
            Doctor d=GetDoctor(doctorId);
            return d.specialization;
        }

        public void RemoveDoctor(int doctorId)
        {
           _doctorRepository.DeleteDoctor(doctorId);
        }

        public void UpdateDoctor(int doctorId, Doctor doctor)
        {
            _doctorRepository.UpdateDoctor(doctorId, doctor);
        }
    }
}
