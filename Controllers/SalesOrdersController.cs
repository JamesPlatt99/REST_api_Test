using Microsoft.AspNetCore.Mvc;
using MyApi.Context;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;

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
                var query = from soh in _context.SalesOrderHeader
                            where soh.CustomerId == customerID
                            select Mapper.Map<Models.SalesOrderHeaderDTO>(soh);
                return query.ToList();
            }
            return null;
        }
#endregion

    }
}