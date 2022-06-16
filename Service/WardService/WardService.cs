using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Entities;
using Data.HospitalCountext;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.WardService
{
    public class WardService: IWardService
    {
        private readonly HospitalContext hospitalContext;
        private readonly IMapper mapper;

        public WardService(HospitalContext hospitalContext,IMapper mapper)
        {
            this.hospitalContext = hospitalContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<T>> GetAsync<T>()
        {

            return await hospitalContext.Wards.ProjectTo<T>(mapper.ConfigurationProvider).ToArrayAsync();
        }
        public async Task<T> GetASS<T>(int id)
        {

            return await hospitalContext.Wards.Where(s => s.Id == id).ProjectTo<T>(mapper.ConfigurationProvider).FirstOrDefaultAsync();
        }
        public async Task CreateAsync<T>(T model)
        {
            var ward = mapper.Map<Ward>(model);
            await hospitalContext.AddAsync(ward);
            await hospitalContext.SaveChangesAsync();
        }
        public async Task Update<T>(T model)
        {
            var ward = mapper.Map<Ward>(model);
            hospitalContext.Update(ward);
            await hospitalContext.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var ward = await hospitalContext.Wards.FindAsync(id);
            hospitalContext.Wards.Remove(ward);
            await hospitalContext.SaveChangesAsync();
        }
    }
}
