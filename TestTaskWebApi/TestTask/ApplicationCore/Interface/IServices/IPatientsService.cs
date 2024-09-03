using TestTask.Anexs.Dto.PatientsDtos;

namespace TestTask.ApplicationCore.Interface.IServices
{
    public interface IPatientsService
    {
        Task<(IEnumerable<GetPatientsDto> patients, int totalPage)> GetPatients(int page, string sort = null, string type = null);

        Task<GetPatientsDto> GetPatientsByID(string id);

        Task<bool> AddPatients(CreatePatientsDto addPatients);

        Task<bool> UpdatePatients(string patientsId, UpdatePatientsDto patients);

        Task<bool> DeletePatients(string patientsId);


    }
}
