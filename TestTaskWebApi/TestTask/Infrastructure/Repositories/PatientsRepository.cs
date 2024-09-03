using Microsoft.EntityFrameworkCore;
using TestTask.Anexs.Dto.PatientsDtos;
using TestTask.ApplicationCore.Interface.IRepositories;
using TestTask.Infrastructure.Data;

namespace TestTask.Infrastructure.Repositories
{
    public class PatientsRepository : IPatientsRepository
    {
        private readonly DataContext dataContext;
        public PatientsRepository(DataContext context)
        {
            this.dataContext = context;
        }
        public async Task<bool> CreatePatientsData(Patients patients)
        {
            patients.id = Guid.NewGuid().ToString();

            dataContext.Add(patients);

            await dataContext.SaveChangesAsync();

            return await SavePatients();
            
        } 
        
        public async Task<ICollection<GetPatientsDto>> GetAllPatients()
        {
            var patients = await dataContext.Patients.Select(p => new GetPatientsDto
            {
                id = p.id,
                firstName = p.firstName,
                lastName = p.lastName,
                middleName = p.middleName,
                address = p.address,
                date_of_birth = p.date_of_birth,
                gender = p.gender,

                areas = p.areas.areasNumber

            }).ToListAsync();

            return patients;
        }
        public async Task<ICollection<GetPatientsDto>> SortPatients(string? sort = null, string? type = null)
        {
            var patients = await GetAllPatients();

            var query = patients.AsQueryable();

            if(!string.IsNullOrEmpty(sort) && !string.IsNullOrEmpty(type))
            {
                switch (sort.ToLower())
                {
                    case "lastname":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.lastName) : query.OrderByDescending(p => p.lastName);
                        break;

                    case "firstname":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.firstName) : query.OrderByDescending(p => p.firstName);
                        break;

                    case "middlename":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.middleName) : query.OrderByDescending(p => p.middleName);
                        break;

                    case "address":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.address) : query.OrderByDescending(p => p.address);
                        break;

                    case "gender":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.gender) : query.OrderByDescending(p => p.gender);
                        break;

                    case "areas":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.areas) : query.OrderByDescending(p => p.areas);
                        break;

                    case "date_of_birth":
                        query = type.ToLower() == "asc" ? query.OrderBy(p => p.date_of_birth) : query.OrderByDescending(p => p.date_of_birth);
                        break;
                }
            }

            return query.ToList();
        }
        public async Task<Patients> GetPatienstById(string patienstId)
        {
            return await dataContext.Patients.Where(p => p.id == patienstId).FirstOrDefaultAsync();
        }
        public async Task<bool> UpdatePatientsData(Patients patients)
        {
            dataContext.Update(patients);

            return await SavePatients();
        }

        public async Task<bool> DeletePatientsData(Patients patients)
        {
            dataContext.Remove(patients);

            return await SavePatients();
        }

        public async Task<bool> SavePatients()
        {
            await dataContext.SaveChangesAsync();

            return true;
        }
 
    }
}
