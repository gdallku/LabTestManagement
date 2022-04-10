﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LabTestManagement.Models
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(60, MinimumLength = 4)]
        public string Name { get; set; }

    }
}
