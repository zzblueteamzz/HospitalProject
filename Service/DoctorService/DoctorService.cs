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

namespace Service.DoctorService
{
    public class DoctorService:IDoctorService
    {
        private readonly HospitalContext hospitalContext;
        private readonly IMapper mapper;

        public DoctorService(HospitalContext dbContext, IMapper mapper)
        {
            this.hospitalContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<T>> GetAsync<T>()
        {
            return await hospitalContext.Doctors.ProjectTo<T>(mapper.ConfigurationProvider).ToArrayAsync();
        }
        public async Task<T> GetASS<T>(int id)
        {

            return await hospitalContext.Doctors.Where(s => s.Id == id).ProjectTo<T>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
        public async Task CreateAsync<T>(T model)
        {
            var doctor = mapper.Map<Doctor>(model);
            await hospitalContext.AddAsync(doctor);
            await hospitalContext.SaveChangesAsync();

        }
        public async Task Update<T>(T model)
        {
            var doctor = mapper.Map<Doctor>(model);
            hospitalContext.Update(doctor);
            await hospitalContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var doctor = await hospitalContext.Doctors.FindAsync(id);
            hospitalContext.Doctors.Remove(doctor);
            await hospitalContext.SaveChangesAsync();
        }
    }
}
