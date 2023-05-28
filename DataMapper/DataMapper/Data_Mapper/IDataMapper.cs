using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper.Data_Mapper
{
    public interface IDataMapper<T>
    {
        public T GetById(int id);
        public bool Save(T Entity);
        public bool Update(int id, T Entity);
        public bool Delete(int id);
        public List<T> GetAll();







    }
}
