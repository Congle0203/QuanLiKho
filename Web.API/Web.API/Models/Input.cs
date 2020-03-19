using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Repository
{
    public class Input
    {
        public int Mapn { get; set; }
        public string Tenpn { get; set; }
        public DateTime Ngaynhap { get; set; }
        public int StockId { get; set; }
       
        public int Soluongnhap { get; set; }
        public string Tinhtrang { get; set; }
        public int Dongianhap { get; set; }
        
        public Stock Stocks { get; set; }





    }

}
