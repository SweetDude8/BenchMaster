using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmolovJrBench.Helpers;
using SmolovJrBench.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SmolovJrBench.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new BenchDataModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SmolovJrAllBenchSessions(BenchDataModel benchDataModel)
        {
            
            if (ModelState.IsValid)
            {
                //i detta skede ska MaxBenchWeight samt Increment vara korrekta tal fast i string type
                AllBenchSessionsModel allBenchSessionsModel = new();

                benchDataModel.MaxBenchWeight = benchDataModel.MaxBenchWeight.Replace(',', '.');
                benchDataModel.Increment = benchDataModel.Increment.Replace(',', '.');
                allBenchSessionsModel.AllSessions = BenchDataHelper.WeightCalculation(double.Parse(benchDataModel.MaxBenchWeight, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture), 
                    double.Parse(benchDataModel.Increment, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture));
                return View(allBenchSessionsModel);
            }

            benchDataModel.ValidationErrors = ModelState.Values
            .SelectMany(state => state.Errors)
            .Select(error => error.ErrorMessage);
            benchDataModel.HasErrors = true;
            return View("Index", benchDataModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
