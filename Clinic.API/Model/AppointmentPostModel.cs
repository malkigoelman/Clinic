using Mirpaha.Entities;

namespace Clinic.API.Model
{
    public class AppointmentPostModel
    {
        public int DoctorId { get; set; }
        public int ClientId { get; set; }

        //public DateTime Date_Time { get; set; }
        public int Room { get; set; }
        public int TreatmentId { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
    }
}
