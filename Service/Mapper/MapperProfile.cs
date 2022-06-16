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

            CreateMap<DoctorCreateViewModel, Doctor>();
            CreateMap<Doctor, DoctorCreateViewModel>();

            CreateMap<PatientViewModel, Patient>();
            CreateMap<Patient, PatientViewModel>();

            CreateMap<WardViewModel, Ward>();
            CreateMap<Ward, WardViewModel>();

            CreateMap<WardCreateViewModel, Ward>();
            CreateMap<Ward, WardCreateViewModel>();
        }
        
    }
}
