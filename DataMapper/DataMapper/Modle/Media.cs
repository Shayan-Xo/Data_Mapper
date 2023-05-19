using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMapper.Modle
{
    public enum Media_type
    {
        Book,
        Magazine,
        Movie
    }

    public class Media
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public Media_type MediaType { get; set; }
    }

}
