using Microsoft.AspNetCore.Mvc;

namespace TestTask.Anexs.Dto.PatientsDtos
{
    public class UpdatePatientsDto
    {
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string address { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }
        public string areasId { get; set; }
    }
}
