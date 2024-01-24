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

        public Doctor AddDoctor(Doctor doctor)
        {
           return _doctorRepository.AddDoctor(doctor);
        }

        public Doctor GetDoctor(int id)
        {
           return _doctorRepository.GetDoctor(id);
        }

        public IEnumerable<Doctor> GetDoctors()
        {
            return _doctorRepository.GetDoctors();
        }

        public IEnumerable<Shift> GetShifts(int doctorId)
        {
            return _doctorRepository.GetShifts(doctorId);
        }

        public IEnumerable<Specialization> GetSpecializations(int doctorId)
        {
            return _doctorRepository.GetSpecializations(doctorId);
        }

        public void RemoveDoctor(int doctorId)
        {
           _doctorRepository.DeleteDoctor(doctorId);
        }

        public Doctor UpdateDoctor(int doctorId, Doctor doctor)
        {
           return _doctorRepository.UpdateDoctor(doctorId, doctor);
        }
    }
}
