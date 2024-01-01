namespace Mirpaha.Entities
{
    public enum Specialization { General, Dentist, Ophthalmologist }
    public enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday }
    public class Doctor
    {
        private static int doctorId = 1;
        public Doctor(int id,string name)
        {
                this.Id = id;
            this.Name = name;
            this.DoctorId= doctorId++;
            this.specialization = new List<Specialization>();
        }
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public Dictionary<int, Specialization> specialization { get; set; }
        public string Phone { get; set; }
        public List<Shift> Shifts { get; set; }
    }
    public class Shift
    {
        public int Id { get; set; }
        public Days Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
