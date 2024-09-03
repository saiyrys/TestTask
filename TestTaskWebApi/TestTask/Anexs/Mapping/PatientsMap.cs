using AutoMapper;
using TestTask.Anexs.Dto.PatientsDtos;

namespace TestTask.Anexs.Mapping
{
    public class PatientsMap : Profile
    {
        public PatientsMap()
        {
            CreateMap<Patients, GetPatientsDto>();
            CreateMap<GetPatientsDto, Patients>();

            CreateMap<Patients, CreatePatientsDto>();
            CreateMap<CreatePatientsDto, Patients>();

            CreateMap<Patients, UpdatePatientsDto>();
            CreateMap<UpdatePatientsDto, Patients>();

        }
    }
}
