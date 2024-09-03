using TestTask.Anexs.Dto.DoctorsDtos;
using TestTask.Anexs.Dto.PatientsDtos;
using TestTask.ApplicationCore.Interface.IRepositories;
using TestTask.Infrastructure.Data;

namespace TestTask.Infrastructure.Repositories
{
    public class DoctorsRepository : IDoctorsRepository
    {
        private readonly DataContext _context;
        public DoctorsRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateDoctorData(Doctors doctors)
        {
            doctors.id = Guid.NewGuid().ToString();

            _context.Add(doctors);

            return await SaveDoctors();
        }

        public async Task<ICollection<GetDoctorsDto>> GetAllDoctors()
        {
            var doctors = await _context.Doctors
                .Select(d => new GetDoctorsDto
                {
                    id = d.id,
                    fullName = d.fullName,
                    specialization = d.specialization.specializationName,
                    cabinets = d.cabinets.cabinetNumber,
                    areas = d.areas.areasNumber

                }).ToListAsync();

            return doctors;
        }

        public async Task<Doctors> GetDoctorsById(string doctorsId)
        {
            return await _context.Doctors.Where(d => d.id == doctorsId).FirstOrDefaultAsync();
        }

        public async Task<ICollection<GetDoctorsDto>> SortDoctors(string? sort = null, string? type = null)
        {
            var doctors = await GetAllDoctors();

            var query = doctors.AsQueryable();

            if (!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(type))
            {
                switch (sort.ToLower())
                {
                    case "fullname":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.fullName) : query.OrderByDescending(p => p.fullName);
                        break;
                    case "specialization":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.specialization) : query.OrderByDescending(p => p.specialization);
                        break;
                    case "cabinet":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.cabinets) : query.OrderByDescending(p => p.cabinets);
                        break;
                    case "areas":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.areas) : query.OrderByDescending(p => p.areas);
                        break;
                }
            }

            return query.ToList();
        }
    
        public async Task<bool> UpdateDoctorsData(Doctors doctors)
        {
            _context.Update(doctors);

            return await SaveDoctors();
        }
        public async Task<bool> DeleteDoctorsData(Doctors doctors)
        {
            _context.Remove(doctors);

            return await SaveDoctors();
        }

        private async Task<bool> SaveDoctors()
        {
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
