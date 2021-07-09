using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bi.Interfaces
{
    public interface IService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task<int> Insert(T reg);
        Task Update(T reg);
        Task Delete(int id);
        Task Delete(T reg);
    }
}
