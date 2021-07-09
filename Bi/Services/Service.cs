using Bi.Interfaces;
using Da.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bi.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IAsyncRepository<T> repository;

        public Service(IAsyncRepository<T> repository)
        {
            this.repository = repository;
        }
        public async Task Delete(int id)
        {
            var reg = await repository.GetById(id);
            await repository.Delete(reg);
            //throw new NotImplementedException();
        }

        public async Task Delete(T reg)
        {
            await repository.Delete(reg);
            //throw new NotImplementedException();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await repository.GetList();
           // throw new NotImplementedException();
        }

        public async Task<T> GetById(int id)
        {
            return await repository.GetById(id);
            // throw new NotImplementedException();
        }

        public async Task<int> Insert(T reg)
        {
            var id = (int)await repository.Insert(reg);
            //throw new NotImplementedException();
            return id;
        }

        public async Task Update(T reg)
        {
            await repository.Update(reg);
           // throw new NotImplementedException();
        }
    }

}
