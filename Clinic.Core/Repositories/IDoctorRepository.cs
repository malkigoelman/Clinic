using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Repositories
{
    public interface IDoctorRepository
    {
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task<Doctor> GetDoctorAsync(int id);
        Task DeleteDoctorAsync(int id);
        Task<Doctor> UpdateDoctorAsync(int id, Doctor doctor);
        Task<Doctor> AddDoctorAsync(Doctor doctor);
        Task<IEnumerable<Shift>> GetShiftsAsync(int id);
        Task<IEnumerable<Specialization>> GetSpecializationsAsync(int id);
    }
}
