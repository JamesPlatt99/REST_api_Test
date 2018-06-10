using System;
using System.Collections.Generic;

namespace MyApi.Entities
{
    public partial class SpecialOfferProductInmem
    {
        public SpecialOfferProductInmem()
        {
            SalesOrderDetailInmem = new HashSet<SalesOrderDetailInmem>();
        }

        public int SpecialOfferId { get; set; }
        public int ProductId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ProductInmem Product { get; set; }
        public SpecialOfferInmem SpecialOffer { get; set; }
        public ICollection<SalesOrderDetailInmem> SalesOrderDetailInmem { get; set; }
    }
}
