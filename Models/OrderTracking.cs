using System;
using System.Collections.Generic;

namespace MyApi.Models
{
    public partial class OrderTracking
    {
        public int OrderTrackingId { get; set; }
        public int SalesOrderId { get; set; }
        public string CarrierTrackingNumber { get; set; }
        public int TrackingEventId { get; set; }
        public string EventDetails { get; set; }
        public DateTime EventDateTime { get; set; }
    }
}
