using AutoMapper;
using Data.Entities;
using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapper
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<DoctorViewModel, Doctor>();
            CreateMap<Doctor, DoctorViewModel>();

            CreateMap<PatientViewModel, Patient>();
            CreateMap<Patient, PatientViewModel>();
        }
        
    }
}
