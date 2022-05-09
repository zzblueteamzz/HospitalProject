using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Ward:BaseModel
    {
        public string Name { get; set; }    
        public int? PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
       
        public int? WardId { get; set; }
    }
}
