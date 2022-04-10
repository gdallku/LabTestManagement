using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabTestManagement.Models
{
    
    public class Doctor
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 4)]
        public string FirstName { get; set;}
        [Required]
        public string Email { get; set; }
        [Required]
        public string Image { get; set; }
        public int Telephone { get; set; }
        [Required]
        public string Description { get; set; }

        public List<Appointments> Appointments { get; set; }

        

    }
}
