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

        public async Task<Doctor> AddDoctorAsync(Doctor doctor)
        {
           return await _doctorRepository.AddDoctorAsync(doctor);
        }

        public async Task<Doctor> GetDoctorAsync(int id)
        {
           return await _doctorRepository.GetDoctorAsync(id);
        }

        public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
        {
            return await _doctorRepository.GetDoctorsAsync();
        }

        public async Task<IEnumerable<Shift>> GetShiftsAsync(int doctorId)
        {
            return await _doctorRepository.GetShiftsAsync(doctorId);
        }

        public async Task<IEnumerable<Specialization>> GetSpecializationsAsync(int doctorId)
        {
            return  await _doctorRepository.GetSpecializationsAsync(doctorId);
        }

        public async Task RemoveDoctorAsync(int doctorId)
        {
           await _doctorRepository.DeleteDoctorAsync(doctorId);
        }

        public async Task<Doctor> UpdateDoctorAsync(int doctorId, Doctor doctor)
        {
           return await _doctorRepository.UpdateDoctorAsync(doctorId, doctor);
        }
    }
}
