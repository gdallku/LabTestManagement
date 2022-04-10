using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabTestManagement.Models
{
    public class Appointments
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(20)]
        public string Email { get; set; }
        [Required]
        public string Contact { get; set; }
        [Required]
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }

        //Relationship
        public int DoctorId { get; set; }
        public Doctor Doctors { get; set; }
    }
}
