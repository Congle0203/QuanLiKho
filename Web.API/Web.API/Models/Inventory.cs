using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Repository
{
    public class Inventory
    {
        public int Makho { get; set; }

        public string Tenkho { get; set; }
       
        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();
        //public ICollection<Input> Inputs { get; set; } = new List<Input>();
        //public ICollection<Output> Outputs { get; set; } = new List<Output>();
    }
}
