using AutoMapper;
using Clinic.API.Model;
using Mirpaha.Entities;

namespace Clinic.API.Mapping
{
    public class ApiMappingProfile: Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<Doctor, DoctorPostModel>().ReverseMap();
            CreateMap<Client, ClientPostModel>().ReverseMap();
            CreateMap<Appointment, AppointmentPostModel>().ReverseMap();
            CreateMap<Comment, CommentPostModel>().ReverseMap();
        }
    }
}
