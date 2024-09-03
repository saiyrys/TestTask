using AutoMapper;
using TestTask.Anexs.Dto.PatientsDtos;
using TestTask.ApplicationCore.Interface.IRepositories;
using TestTask.ApplicationCore.Interface.IServices;
using TestTask.Infrastructure.Data;

namespace TestTask.ApplicationCore.Services
{
    public class PatientsService : IPatientsService
    {
        private readonly IPatientsRepository _patientsRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        public PatientsService(IPatientsRepository patientsRepository, IMapper mapper, DataContext context)
        {
            _patientsRepository = patientsRepository;
            _mapper = mapper;
            _context = context;
        }
        public async Task<(IEnumerable<GetPatientsDto> patients, int totalPage)> GetPatients(int page, string? sort = null, string? type = null)
        {
            int pageSize = 15;

            var patients = await _patientsRepository.GetAllPatients();

            if (sort != null || type != null)
            {
                patients = await _patientsRepository.SortPatients(sort, type);
            }

            var patientsDto = _mapper.Map<List<GetPatientsDto>>(patients); 

            var pagination = await Pagination(patientsDto, page, pageSize);

            patientsDto = pagination.Item1;

            var totalPages = pagination.Item2;

            return (patientsDto, totalPages );
        }

        public async Task<GetPatientsDto> GetPatientsByID(string id)
        {
            var patients = await _patientsRepository.GetAllPatients();

            var currentPatients = patients.Where(p => p.id == id).FirstOrDefault();

            return currentPatients;
        }
        public async Task<bool> AddPatients(CreatePatientsDto addPatient)
        {
            var patients = await _patientsRepository.GetAllPatients();

            var existPatients = patients.FirstOrDefault(p => p.id.Trim().ToUpper() == patients.Select(p => p.id).FirstOrDefault());

            if (existPatients != null)
                throw new ArgumentNullException("Пациент с таким id уже сущетсвует");

            var patientsMap = _mapper.Map<Patients>(addPatient);
            if(!await _patientsRepository.CreatePatientsData(patientsMap))
            {
                throw new ArgumentNullException();
            }

            return true;
        }

        public async Task<bool> UpdatePatients(string patientsId, UpdatePatientsDto patients)
        {
            var update = new UpdateModelsService(_context);

            var success = await update.UpdateModel<Patients, UpdatePatientsDto>(patientsId, patients);

            var currentPatients = await _patientsRepository.GetPatienstById(patientsId);

            if (!success || !await _patientsRepository.UpdatePatientsData(currentPatients))
            {
                throw new ArgumentException("Ошибка при обновлении данных пользователя");
            }


            return true;
        } 
        public async Task<bool> DeletePatients(string patientsId)
        {
            var patientsDelete = await _patientsRepository.GetPatienstById(patientsId);

            if(!await _patientsRepository.DeletePatientsData(patientsDelete))
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
