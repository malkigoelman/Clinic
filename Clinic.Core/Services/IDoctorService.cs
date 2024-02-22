using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorAsync(int id);
        Task<IEnumerable<Specialization>> GetSpecializationsAsync(int doctorId);
        Task<IEnumerable<Shift>> GetShiftsAsync(int doctorId);
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task RemoveDoctorAsync(int doctorId);
        Task<Doctor> UpdateDoctorAsync(int doctorId,Doctor doctor);

    }
}
