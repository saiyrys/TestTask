
using TestTask.Anexs.Dto.PatientsDtos;

namespace TestTask.ApplicationCore.Interface.IRepositories
{
    public interface IPatientsRepository
    {
        Task<bool> CreatePatientsData(Patients patients);
        Task<ICollection<GetPatientsDto>> GetAllPatients();
        Task<ICollection<GetPatientsDto>> SortPatients(string? sort = null, string? type = null);
        Task<Patients> GetPatienstById(string patienstId);
        Task<bool> UpdatePatientsData(Patients patients);
        Task<bool> DeletePatientsData(Patients patients);
    }
}
