using Data.Entities;
using Data.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.ViewModels
{
    public class DoctorCreateViewModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Knowledge { get; set; }
        [Required, MaxLength(100)]
        public string Contacts { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public int SpecialityId { get; set; }
        public HospitalRoles Speciality { get; set; }
        public int WardId { get; set; }
        public virtual Ward Ward { get; set; }
    }
}
