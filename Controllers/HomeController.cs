using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebCosmetic.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace WebCosmetic.Controllers
{
    public class HomeController : Controller
    {
        static string result { get; set; }
        public ActionResult IndexHome()
        {
            if(result !=null)
            {
                ViewData["result"] = result;
            }    
            var getAllDataJson = System.IO.File.ReadAllText("ProductData.json");
            ViewData["ProductDataJson"] = JsonConvert.DeserializeObject<Dictionary<string, List<ProductDataJson>>>(getAllDataJson);
            return View();
        }

        [HttpPost]
        public ActionResult RegisterAnnouncement(string email)
        {
            DataTransfer dt = new DataTransfer();
            if (dt.RegisterAnnoucement(email))
            {
                result = "Đăng kí thông tin thành công";
            }    
            else
            {
                result = "Đăng kí thông tin thất bại do email sai";
            }    
            return IndexHome();
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


