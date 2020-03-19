using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.API.Repository;

namespace Web.API.Repository
{
    public class Stock
    {

        public int Mavt { get; set; }
        public string Tenvt { get; set; }
        public int Soluong { get; set; }

        public string Noisx { get; set; }

        public int InventoryId { get; set; }
        public int UnitId { get; set; }
        public int SupplierId { get; set; }

        public Inventory Inventory { get; set; }
        public Unit Unit { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<Output> Outputs { get; set; } = new List<Output>();
        public ICollection<Input> Inputs { get; set; } = new List<Input>();


    }
}
