using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Resources
{
    public class InputsItemViewModel
    {
        public int Mapn { get; set; }
        public string Tenpn { get; set; }
        public DateTime Ngaynhap { get; set; }
        public int StockId { get; set; }

        public int Soluongnhap { get; set; }
        public string Tinhtrang { get; set; }
        public int Dongianhap { get; set; }

        public string Stockname { get; set; }
    }
}
