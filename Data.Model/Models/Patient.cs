using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Patient: BaseModel
    {
        public string Name { get; set; }
        public string Symptoms { get; set; }
        public virtual ICollection<Ward> Wards { get; set; }

    }
}
