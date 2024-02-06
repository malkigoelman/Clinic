using Mirpaha.Entities;

namespace Clinic.API.Model
{
    public class DoctorPostModel
    {
        public string Name { get; set; }
        public int TzNumber { get; set; }
        //public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
