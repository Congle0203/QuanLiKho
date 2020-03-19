using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Repository;

namespace Web.API.Repository
{
    public class Supplier
    {
        public int Mancc { get; set; }
        public string Tenncc { get; set; }
       
        public string Diachi { get; set; }
        public int Sdt { get; set; }

        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        //public ICollection<Input> Inputs { get; set; } = new List<Input>();
    }
}
