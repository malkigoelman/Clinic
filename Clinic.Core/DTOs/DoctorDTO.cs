using Mirpaha.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core.DTOs
{
    public class DoctorDTO
    {
        public string Name { get; set; }
        //public DateTime Birthday { get; set; }
        public string Address { get; set; }
        //public List<Specialization> Specialization { get; set; }
        public string Phone { get; set; }
    }
}
