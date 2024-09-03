using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Anexs.Mapping
{
    public class DoctorsMap : Profile
    {
        public DoctorsMap()
        {
            CreateMap<Doctors, GetDoctorsDto>();
            CreateMap<GetDoctorsDto, Doctors>();

            CreateMap<Doctors, CreateDoctorsDto>();
            CreateMap<CreateDoctorsDto, Doctors>();

            CreateMap<Doctors, UpdateDoctorsDto>();
            CreateMap<UpdateDoctorsDto, Doctors>();
        }
    }
}
