using System.ComponentModel.DataAnnotations.Schema;

namespace TestTask.ApplicationCore.Models
{
    public class Doctors
    {
        public string id { get; set; }
        public string fullName { get; set; }

        public string specializationId { get; set; }
        public string cabinetsId { get; set; }
        public string areasId { get; set; }

        [ForeignKey("cabinetsId")]
        public virtual Cabinets cabinets { get; set; }
        [ForeignKey("specializationId")]
        public virtual Specialization specialization { get; set; }
        [ForeignKey("areasId")]
        public virtual Areas areas { get; set; }
    }
}
