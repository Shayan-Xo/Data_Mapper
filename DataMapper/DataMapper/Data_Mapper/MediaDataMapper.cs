using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataMapper.Modle; 

namespace DataMapper.Data_Mapper
{
    public class MediaDataMapper : IDataMapper<Media>
    {
        public Task<Media> Create(Media Entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Media> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Media> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Media> Update(int id, Media Entity)
        {
            throw new NotImplementedException();
        }
    }
}
