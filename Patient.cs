using System;
using System.ComponentModel.DataAnnotations;

namespace CityHospitalManagement.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string Contact { get; set; }

        public string MedicalHistory { get; set; }
    }
}
