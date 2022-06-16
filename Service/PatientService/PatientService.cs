using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Entities;
using Data.HospitalCountext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PatientService
{
    public class PatientService : IPatientService
    {
        private readonly HospitalContext hospitalContext;
        private readonly IMapper mapper;
        public PatientService(HospitalContext hospitalContext, IMapper mapper)
        {
            this.hospitalContext = hospitalContext;
            this.mapper = mapper;
        }

        public async Task CreateAsync<T>(T model)
        {
            var patiet = mapper.Map<Patient>(model);
            await hospitalContext.AddAsync(patiet);
            await hospitalContext.SaveChangesAsync();
        }
        public async Task Update<T>(T model)
        {
            var patiet = mapper.Map<Patient>(model);
             hospitalContext.Update(patiet);
            await hospitalContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var patient = await hospitalContext.Patients.FindAsync(id);
            hospitalContext.Patients.Remove(patient);
            await hospitalContext.SaveChangesAsync();
        }
        public async Task<T> GetAsync<T>(int id)
        {
            
            return await hospitalContext.Patients.Where(s=>s.Id==id).ProjectTo<T>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
    }
}
