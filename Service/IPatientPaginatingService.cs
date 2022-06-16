using Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPatientPaginatingService
    {
        public Task<PaginationViewModel> GetPageAsync(string searchString, int pageIndex, int pageSize);

    }
}
