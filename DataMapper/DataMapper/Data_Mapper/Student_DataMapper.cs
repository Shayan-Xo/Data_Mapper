using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMapper.Modle;

namespace DataMapper.Data_Mapper
{
    public class Student_DataMapper : IDataMapper<Student>
    {
        public Task<Student> Create(Student Entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Student> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Student> Update(int id, Student Entity)
        {
            throw new NotImplementedException();
        }
    }
}
