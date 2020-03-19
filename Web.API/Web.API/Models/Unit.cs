using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Repository
{
    public class Unit
    {
        public int Madv { get; set; }
        public string Tendv { get; set; }

        public string Description { get; set; }
        public IList<Stock> Stocks { get; set; } = new List<Stock>();
    }
}
