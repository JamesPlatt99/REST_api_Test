using System.Collections.Generic;

namespace MyApi.Models
{
    public class SalesOrderDTO
    {
        public IEnumerable<SalesOrderDetailDTO> salesOrderDetails;
    }
}