using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Taxi_Depot.DAL;
using Taxi_Depot.DAL.Enums;
using Taxi_Depot.Models;

namespace Taxi_Depot.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly MainContext _mainContext;
        private static int EditId;

        public OrdersController(ILogger<OrdersController> logger, MainContext mainContext)
        {
            _logger = logger;
            _mainContext = mainContext;
        }

        public IActionResult Index()
        {
            var res = _mainContext.Orders.OrderBy(x => x.Status).ToList();

            return View(res);
        }

        public IActionResult EditOrder(int id) 
        {
            var res = _mainContext.Orders.Where(x => x.Id == id).ToList();
            EditId = id;

            return View(res);
        }

        [HttpPost]
        public RedirectResult SendOrder(string FullName, string ClientPhone, string From, string Where, int Cost)
        {
            var res = _mainContext.Orders.FirstOrDefault(x => x.Id == EditId);

            res.FullName = FullName;
            res.ClientPhone = ClientPhone;
            res.From = From;
            res.Where = Where;
            res.Cost = Cost;

            _mainContext.SaveChanges();

            return Redirect("/Orders");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
