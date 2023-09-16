using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Odev1.Entities;

namespace Odev1.Controllers
{
    public class OrdersController : Controller
    {
        private readonly NorthwindContext dbContext;

        public OrdersController(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IActionResult> Index(int id)
        {
            var orders = dbContext.Orders.Where(p => p.EmployeeId == id).ToList();
            return View(orders);
        }
    }
}
