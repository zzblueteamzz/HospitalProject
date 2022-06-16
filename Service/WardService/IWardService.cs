using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.WardService
{
    public interface IWardService
    {
        public Task<IEnumerable<T>> GetAsync<T>();
        public Task CreateAsync<T>(T model);
        public Task Delete(int id);
    }
}
