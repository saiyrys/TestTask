

namespace TestTask.ApplicationCore.Interface.IRepositories
{
    public interface IDoctorsRepository
    {
        Task<bool> CreateDoctorData(Doctors doctors);
        Task<ICollection<GetDoctorsDto>> GetAllDoctors();
        Task<ICollection<GetDoctorsDto>> SortDoctors(string? sort = null, string? type = null);
        Task<Doctors> GetDoctorsById(string doctorsId);
        Task<bool> UpdateDoctorsData(Doctors doctors);
        Task<bool> DeleteDoctorsData(Doctors doctors);
    }
}
