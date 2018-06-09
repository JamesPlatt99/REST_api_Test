using System;
using System.Collections.Generic;

namespace MyApi.Models
{
    public partial class DemoSalesOrderDetailSeed
    {
        public short OrderQty { get; set; }
        public int ProductId { get; set; }
        public int SpecialOfferId { get; set; }
        public int OrderId { get; set; }
        public int LocalId { get; set; }
    }
}
