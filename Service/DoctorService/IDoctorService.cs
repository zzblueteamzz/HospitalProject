using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DoctorService
{
    public interface IDoctorService
    {
       public Task<IEnumerable<T>> GetAsync<T>();
        public  Task Delete(int id);
    }
}
