using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Services
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctor(int id);
        Specialization GetSpecializations(int doctorId);
        Doctor AddDoctor(Doctor doctor);
        void RemoveDoctor(int doctorId);
        Doctor UpdateDoctor(int doctorId,Doctor doctor);
    }
}
