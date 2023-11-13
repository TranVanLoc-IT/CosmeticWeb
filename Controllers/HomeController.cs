using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebCosmetic.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebCosmetic.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult IndexHome()
        {
            var getAllDataJson = System.IO.File.ReadAllText("ProductData.json");
            ViewData["ProductDataJson"] = JsonConvert.DeserializeObject<Dictionary<string, List<ProductDataJson>>>(getAllDataJson);
            return View();
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


