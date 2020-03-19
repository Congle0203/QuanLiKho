using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Resources
{
    public class OutputsItemViewModel
    {
        public int Mapx { get; set; }
        public string Tenpx { get; set; }
        public int Soluongxuat { get; set; }
        public DateTime Ngayxuat { get; set; }
        public string Tinhtrangxuat { get; set; }
        public int Dongiaxuat { get; set; }

        public int Thanhtien { get; set; }
        public string Customername { get; set; }
        public string Stockname { get; set; }   
       
        public int IdStock { get; set; }
        public int CustomerId { get; set; }


    }
}
