using Data.Entities;
using Data.Model.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Data.ViewModels
{
    public class DoctorViewModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Knowledge { get; set; }
        [MaxLength(100)]
        public string Contacts { get; set; }
        public string UserFirstName { get; set; }
        public string SpecialityName { get; set; }
        public string WardName { get; set; }
    }
}
