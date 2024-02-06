using AutoMapper;
using Clinic.Core.DTOs;
using Mirpaha.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinic.Core
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Client, ClientDTO>().ReverseMap();
            CreateMap<Appointment, AppointmentDTO>().ReverseMap();
        }
    }
}
