using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Repository
{

    public class Customer
    {
        public int Makh { get; set; }
        public string Tenkh { get; set; }
        public string Diachi { get; set; }
        public int Sdt { get; set; }

        public ICollection<Output> Output { get; set; } = new List<Output>();
    }
}
