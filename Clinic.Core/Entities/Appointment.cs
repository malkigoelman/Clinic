namespace Mirpaha.Entities
{
    public class Appointment
    {
        private static int id = 1;
        public Appointment( int doctorId, int clientId)
        {
            Id = id++;
            DoctorId = doctorId;
            ClientId = clientId;
        }

        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int ClientId { get; set; }
       // public TimeOnly Time { get; set; }
        //public DateOnly Date { get; set; }
        public DateTime Date_Time { get; set; }
        public int Room { get; set; }
        public Specialization Treatment { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
    }
}
