using Microsoft.AspNetCore.Mvc;
using MyApi.Context;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    public class SalesOrderDetailsController : Controller
    {
#region Properties
        private AdventureWorks2016CTP3Context _context;
#endregion

#region Constructor
        public SalesOrderDetailsController(Context.AdventureWorks2016CTP3Context context)
        {
            _context = context;
        }
#endregion

#region API Calls
        [HttpGet("{CustomerID}")]
        public IActionResult SalesOrderDetails(int customerID)
        {
            return new JsonResult(GetSalesOrderDetail(customerID));
        }
#endregion

#region  Helper Methods
        private IEnumerable<Models.SalesOrderDTO> GetSalesOrderDetail(int customerID)
        {
            var query = from soh in _context.SalesOrderHeader
                        join sod in _context.SalesOrderDetail on soh.SalesOrderId equals sod.SalesOrderId
                        where soh.CustomerId == customerID
                        select new Models.SalesOrderDTO{
                            OrderDate = soh.OrderDate,
                            DueDate = soh.DueDate,
                            ShippingDate = soh.ShipDate.GetValueOrDefault(),
                            SalesOrderNumber = soh.SalesOrderNumber,
                            Status = Helpers.EnumerationExtensions.OrderStatusExtension(soh.Status)
                        };
            return query;
        }
#endregion

    }
}