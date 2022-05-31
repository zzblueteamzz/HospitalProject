using Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testing.Interfaces;

namespace Data.Entities
{
    public class Ward:IBaseInterface
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }    
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
       
       
    }
}
