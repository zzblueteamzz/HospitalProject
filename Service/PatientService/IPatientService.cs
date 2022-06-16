using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PatientService
{
    public interface IPatientService
    {
        public Task CreateAsync<T>(T model);

        public Task Update<T>(T model);
        public Task Delete(int id);
        public Task<T> GetAsync<T>(int id);

    }
}
