
using Data.Model;
using Data.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Interfaces;

namespace Data.Entities
{
    public class Doctor : IBaseInterface
    {
        public int Id { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

        public int SpecialityId { get; set; }
        public HospitalRoles Speciality { get; set; }
        public int WardId { get; set; }
        public virtual Ward Ward { get; set; }
        
    }
}
