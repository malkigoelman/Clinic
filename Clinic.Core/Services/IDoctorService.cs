using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Services
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctor(int id);
        IEnumerable<Specialization> GetSpecializations(int doctorId);
        IEnumerable<Shift> GetShifts(int doctorId);
        Doctor AddDoctor(Doctor doctor);
        void RemoveDoctor(int doctorId);
        Doctor UpdateDoctor(int doctorId,Doctor doctor);

    }
}
