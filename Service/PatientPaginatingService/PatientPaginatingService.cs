using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.HospitalCountext;
using Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class PatientPaginatingService:IPatientPaginatingService
    {
        private readonly HospitalContext context;
        private readonly IMapper mapper;
        public PatientPaginatingService(HospitalContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<PaginationViewModel> GetPageAsync(string searchString, int pageIndex, int pageSize)
        {
            var query = context.Patients.AsQueryable();
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(s => s.Name.Contains(searchString));
            }
            var count = await query.CountAsync();
            var totalPages = (int)Math.Ceiling(count / (double)pageSize);


            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ProjectTo<PatientViewModel>(mapper.ConfigurationProvider).ToListAsync();
            return new PaginationViewModel
            {
                PageIndex = pageIndex,
                PageItems = items,
                HasNextPage =  pageIndex < totalPages,
                HasPreviousPage = pageIndex > 1,
            };
        }

    }
}
