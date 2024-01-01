using Mirpaha.Entities;

namespace Mirpaha.Clinic.Core.Repositories
{
    public interface IDoctorRepository
    {
        IEnumerable<Doctor> GetDoctors();
        Doctor GetDoctor(int id);
        void DeleteDoctor(int id);
        void UpdateDoctor(int id,Doctor doctor);
        void AddDoctor(Doctor doctor);    
    }
}
