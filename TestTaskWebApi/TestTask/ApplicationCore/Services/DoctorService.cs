using AutoMapper;
using TestTask.ApplicationCore.Interface.IRepositories;
using TestTask.ApplicationCore.Interface.IServices;
using TestTask.Infrastructure.Data;
using TestTask.Infrastructure.Repositories;

namespace TestTask.ApplicationCore.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorsRepository _doctorsRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public DoctorService(IDoctorsRepository doctorsRepository, IMapper mapper, DataContext context)
        {
            _doctorsRepository = doctorsRepository;
            _mapper = mapper;
            _context = context;
            
        }
        public async Task<(IEnumerable<GetDoctorsDto> doctors, int totalPage)> GetAllDoctors(int page, string? sort = null, string? type = null)
        {
            int pageSize = 15;

            var doctors = await _doctorsRepository.GetAllDoctors();

            if (sort != null || type != null)
            {
                doctors = await _doctorsRepository.SortDoctors(sort, type);
            }

            var doctorsDto = _mapper.Map<List<GetDoctorsDto>>(doctors);

            var pagination = await Pagination(doctorsDto, page, pageSize);

            doctorsDto = pagination.Item1;

            var totalPages = pagination.Item2;

            return (doctorsDto, totalPages);
        }
        public async Task<GetDoctorsDto> GetDoctorsByID(string doctorsId)
        {
            var doctor = await _doctorsRepository.GetAllDoctors();

            var currentDoctor = doctor.Where(d => d.id == doctorsId).FirstOrDefault();

            if(currentDoctor == null)
            {
                throw new ArgumentNullException();
            }

            return currentDoctor;
            
        }
        public async Task<bool> AddDoctorsData(CreateDoctorsDto addDoctors)
        {
            var doctorsMap = _mapper.Map<Doctors>(addDoctors);

            if(!await _doctorsRepository.CreateDoctorData(doctorsMap))
            {
                throw new ArgumentNullException();
            }

            return true;
        }
        public async Task<bool> UpdateDoctorsData(string doctorsId, UpdateDoctorsDto doctors)
        {
            var update = new UpdateModelsService(_context);

            var success = await update.UpdateModel<Doctors, UpdateDoctorsDto>(doctorsId, doctors);

            var currentDoctors = await _doctorsRepository.GetDoctorsById(doctorsId);

            if(!await _doctorsRepository.UpdateDoctorsData(currentDoctors))
            {
                throw new ArgumentNullException();
            }

            return true;
        }
        public async Task<bool> DeleteDoctors(string doctorsId)
        {
            var doctorToDelete = await _doctorsRepository.GetDoctorsById(doctorsId);

            if(!await _doctorsRepository.DeleteDoctorsData(doctorToDelete))
            {
                throw new ArgumentNullException();
            }

            return true;
        }

        private async Task<Tuple<List<T>, int>> Pagination<T>(List<T> items, int page, int pageSize)
        {
            int totalItems = items.Count();
            int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

            int skip = (page - 1) * pageSize;
            var itemsForPage = items.Skip(skip).Take(pageSize).ToList();

            return Tuple.Create(itemsForPage, totalPages);
        }


    }
}
