﻿using System;
using System.Collections.Generic;

namespace MyApi.Models
{
    public partial class SpecialOfferInmem
    {
        public SpecialOfferInmem()
        {
            SpecialOfferProductInmem = new HashSet<SpecialOfferProductInmem>();
        }

        public int SpecialOfferId { get; set; }
        public string Description { get; set; }
        public decimal DiscountPct { get; set; }
        public string Type { get; set; }
        public string Category { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int MinQty { get; set; }
        public int? MaxQty { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ICollection<SpecialOfferProductInmem> SpecialOfferProductInmem { get; set; }
    }
}
