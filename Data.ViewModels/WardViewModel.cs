﻿using Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class WardViewModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public string PatientName { get; set; }
    }
}
