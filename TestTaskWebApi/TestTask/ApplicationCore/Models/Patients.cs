using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.ApplicationCore.Models
{
    public class Patients
    {
        public string id { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string address { get; set; }
        public DateTime date_of_birth { get; set; }
        public string gender { get; set; }

        public string areasId { get; set; }

        [ForeignKey("areasId")]
        public virtual Areas areas { get; set; }
    }
}
