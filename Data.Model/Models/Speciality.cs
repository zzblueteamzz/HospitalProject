﻿using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Speciality: BaseModel
    {
        [Required, MaxLength(40)]
        public string Name { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}