
using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Doctor : BaseModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Speciality> Specialitys { get; set; }
        public int SpecialityId { get; set; }
      
        public int? WardId { get; set; }
        public virtual Ward Ward { get; set; }
       

    }
}
