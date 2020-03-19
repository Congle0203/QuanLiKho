using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.API.Resources
{
    public class StocksItemViewModel
    {
        public int Mavt { get; set; }
        public string Tenvt { get; set; }
        public int Soluong { get; set; }
        public string Noisx { get; set; }
        public int InventoryId { get; set; }
        public string Inventoryname { get; set; }
        public int UnitId { get; set; }
        public string Unitname { get; set; }
        public string Suppliername { get; set; }
        public int SupplierId { get; set; }

    }
}
