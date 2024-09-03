namespace TestTask.ApplicationCore.Interface.IServices
{
    public interface IDoctorService
    {
        Task<(IEnumerable<GetDoctorsDto> doctors, int totalPage)> GetAllDoctors(int page, string? sort = null, string? type = null);
        Task<GetDoctorsDto> GetDoctorsByID(string doctorsId);
        Task<bool> AddDoctorsData(CreateDoctorsDto addDoctors);
        Task<bool> UpdateDoctorsData(string doctorsId, UpdateDoctorsDto doctors);
        Task<bool> DeleteDoctors(string doctorsId);
    }
}
