using AutoMapper;
using AutoMapper.QueryableExtensions;
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
        private readonly HospitalContext dbContext;
        private readonly IMapper mapper;

        public DoctorService(HospitalContext dbContext, IMapper mapper)
        {
            this.dbContext = dbContext;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<T>> GetAsync<T>()
        {

            return await dbContext.Doctors.ProjectTo<T>(mapper.ConfigurationProvider).ToArrayAsync();
        }
    }
}
