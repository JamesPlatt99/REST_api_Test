using System;
using System.Collections.Generic;

namespace MyApi.Models
{
    public partial class SpecialOfferProductOndisk
    {
        public SpecialOfferProductOndisk()
        {
            SalesOrderDetailOndisk = new HashSet<SalesOrderDetailOndisk>();
        }

        public int SpecialOfferId { get; set; }
        public int ProductId { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ProductOndisk Product { get; set; }
        public SpecialOfferOndisk SpecialOffer { get; set; }
        public ICollection<SalesOrderDetailOndisk> SalesOrderDetailOndisk { get; set; }
    }
}
