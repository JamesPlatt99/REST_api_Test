using Microsoft.AspNetCore.Mvc;
using MyApi.Context;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.QueryableExtensions;

namespace MyApi.Controllers
{
    [Route("api/customers/{customerID}/Orders")]
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
        [HttpGet()]
        public IActionResult SalesOrders(int customerID)
        {
            var salesOrders = GetSalesOrders(customerID);
            if (salesOrders != null){
                return new JsonResult(GetSalesOrders(customerID));
            }
            return NotFound();
        }
#endregion

#region  Helper Methods
        private List<Models.SalesOrderHeaderDTO> GetSalesOrders(int customerID)
        {
            if(_context.Customer.Any(n => n.CustomerId == customerID)){
                var query = (from soh in _context.SalesOrderHeader
                             where soh.CustomerId == customerID
                             select soh).ProjectTo<Models.SalesOrderHeaderDTO>();
                return query.ToList();
            }
            return null;
        }
#endregion

    }
}