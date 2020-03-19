using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Repository
{
    public class Output
    {

        public int Mapx { get; set; }
        public string Tenpx { get; set; }
        public string Tinhtrangxuat { get; set; }
        public DateTime Ngayxuat { get; set; }
        public int Soluongxuat { get; set; }
        public int Dongiaxuat { get; set; }
        public int Thanhtien { get; set; }
      
        public int IdStock { get; set; }
        public int CustomerId { get; set; }
       

        public Customer Customer { get; set; }
        public Stock Stocks { get; set; }
        //public Inventory Inventory { get; set; }
    }
}
