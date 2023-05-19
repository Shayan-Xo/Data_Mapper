using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper.Data_Mapper
{
    public interface IDataMapper<T>
    {
        public Task<T> GetById(int id);
        public Task<T> Create(T Entity);
        public Task<T> Update(int id, T Entity);
        public Task<bool> Delete(int id);
        public Task<T> GetAll();







    }
}
