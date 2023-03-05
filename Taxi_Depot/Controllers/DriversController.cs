using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Taxi_Depot.DAL;
using Taxi_Depot.DAL.Models;
using Taxi_Depot.Models;


namespace Taxi_Depot.Controllers
{
    public class DriversController : Controller
    {
        private readonly ILogger<DriversController> _logger;
        private readonly MainContext _mainContext;
        private static int EditId;
        private static Driver driver;

        public DriversController(ILogger<DriversController> logger, MainContext mainContext)
        {
            _logger = logger;
            _mainContext = mainContext;
        }

        public IActionResult Index()
        {
            var res = _mainContext.Drivers.ToList();

            return View(res);
        }

        public IActionResult EditDriver(int id)
        {
            var res = _mainContext.Drivers.Where(x => x.Id == id).ToList();
            EditId = id;

            return View(res);
        }

        [HttpPost]
        public RedirectResult SendDriver(string Name, string Surname, string Phone)
        {
            var res = _mainContext.Drivers.FirstOrDefault(x => x.Id == EditId);

            res.Name= Name;
            res.Surname= Surname;
            res.Phone= Phone;

            _mainContext.SaveChanges();

            return Redirect("/Drivers");
        }

        public IActionResult ViewTransports(int id)
        {
            var res = _mainContext.Transports.Where(x => x.DriverId == id).ToList();
            driver = _mainContext.Drivers.FirstOrDefault(x => x.Id == id);

            return View(res);
        }

        public RedirectResult DeleteTransport(int id)
        {
            var res = _mainContext.Transports.FirstOrDefault(x => x.Id == id);

            _mainContext.Transports.Remove(res);
            _mainContext.SaveChanges();

            return Redirect("/Drivers");
        }

        public IActionResult InsertTransport()
        {
            return View();
        }

        [HttpPost]
        public RedirectResult SendTransport(string StateNumber, string Mark, int Year, string Color, bool Seller)
        {
            Transport transport = new Transport
            {
                StateNumber = StateNumber,
                Mark = Mark,
                Year = Year,
                Color = Color,
                Seller = Seller,
                DriverId = driver.Id
            };

            _mainContext.Transports.Add(transport);
            _mainContext.SaveChanges();

            return Redirect("/Drivers");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
