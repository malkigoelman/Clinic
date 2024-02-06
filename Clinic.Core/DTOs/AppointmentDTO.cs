using Mirpaha.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.DTOs
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        
        public int DoctorId { get; set; }
        
        public int ClientId { get; set; }
       
        //public DateTime Date_Time { get; set; }
        public int Room { get; set; }
        //public int TreatmentId { get; set; }
        public Specialization Treatment { get; set; }
        public int Price { get; set; }
        public int Duration { get; set; }
    }
}
