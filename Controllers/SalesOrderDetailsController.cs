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
        [HttpGet("{salesOrderID}")]
        public IActionResult SalesOrderDetails(int salesOrderID)
        {
            return new JsonResult(GetSalesOrderDetail(salesOrderID));
        }
#endregion

#region  Helper Methods
        private IEnumerable<Models.SalesOrderDetail> GetSalesOrderDetail(int salesOrderID)
        {
            var query = from o in _context.SalesOrderDetail
                        where o.SalesOrderId == salesOrderID
                        select o;
            return query;
        }
#endregion

    }
}