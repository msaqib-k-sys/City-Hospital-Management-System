using System.ComponentModel.DataAnnotations;

namespace CityHospitalManagement.Models
{
    public class Doctor
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Specialization { get; set; }

        public string Ward { get; set; }

        public bool Available { get; set; }
    }
}
