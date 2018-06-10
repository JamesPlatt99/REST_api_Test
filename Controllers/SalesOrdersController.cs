using Microsoft.AspNetCore.Mvc;
using MyApi.Context;
using System.Collections.Generic;
using System.Linq;

namespace MyApi.Controllers
{
    [Route("api/[controller]")]
    public class SalesOrdersController : Controller
    {
#region Properties
        private AdventureWorks2016CTP3Context _context;
#endregion

#region Constructor
        public SalesOrdersController(Context.AdventureWorks2016CTP3Context context)
        {
            _context = context;
        }
#endregion

#region API Calls
        [HttpGet("{CustomerID}")]
        public IActionResult SalesOrders(int customerID)
        {
            return new JsonResult(GetSalesOrders(customerID));
        }
#endregion

#region  Helper Methods
        private IEnumerable<Models.SalesOrderDTO> GetSalesOrders(int customerID)
        {
            var query = from soh in _context.SalesOrderHeader
                        where soh.CustomerId == customerID
                        select new Models.SalesOrderDTO()
                        {
                            OrderDate = soh.OrderDate,
                            DueDate = soh.DueDate,
                            ShippingDate = soh.ShipDate.GetValueOrDefault(),
                            SalesOrderNumber = soh.SalesOrderNumber,
                            Status = Helpers.EnumerationExtensions.OrderStatusExtension(soh.Status),
                            SalesOrderDetails = soh.SalesOrderDetail.Select(sod => new Models.SalesOrderDetailDTO()
                            {                            
                                UnitPrice = sod.UnitPrice,
                                OrderQty = sod.OrderQty,
                                LineTotal = sod.LineTotal,
                                ProductID = sod.ProductId
                            })
                        };
            return query;
        }
#endregion

    }
}