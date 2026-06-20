using System;
namespace CityHospitalManagement.Models
{
    public class Admission
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public string Ward { get; set; }

        public int BedNo { get; set; }

        public DateTime AdmissionDate { get; set; }

        public DateTime? DischargeDate { get; set; }
    }
}
