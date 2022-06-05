using Data.Model;
using Data.Model.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
   
    public class HospitalRoles: IdentityRole<int>
    {
        
        public HospitalRoles()
        {

        }
        public HospitalRoles(string name) : base(name)
        {

        }
        [Required, MaxLength(40)]
        public override string Name { get; set; }
        
    }
}
