namespace Mirpaha.Entities
{
    public enum SpecializationEnum { General, Dentist, Ophthalmologist }
    public enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday }
    public class Doctor
    {
        
        public int Id { get; set; }
        public int Tz { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public string Address { get; set; }
        public List<Specialization> Specialization { get; set; }
        public string Phone { get; set; }
        public List<Shift> Shifts { get; set; }
    }
    public class Shift
    {
        public int Id { get; set; }
        public Days Day { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public Doctor Doctor { get; set; }
    }
    public class Specialization
    {
        public int Id { get; set; }
        public SpecializationEnum specialization { get; set; }
    }

}
