using System;
using System.Collections.Generic;

namespace MyApi.Models
{
    public class SalesOrderDTO
    {
        public String SalesOrderNumber;
        public String Status;
        public DateTime OrderDate;
        public DateTime ShippingDate;
        public DateTime DueDate;
        public IEnumerable<SalesOrderDetailDTO> SalesOrderDetails;
    }
}