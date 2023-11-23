using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using WebCosmetic.Models;
namespace WebCosmetic.Controllers
{
    public class CatalogController : Controller
    {
        private DataTransfer db = new DataTransfer();
        private static List<ProductCardModel> pCards = new List<ProductCardModel>();

        public IActionResult IndexCatalog([FromQuery]string catalog)
        {

            var getAllDataJson = System.IO.File.ReadAllText("ProductData.json");
            ViewData["ProductDataJson"] = JsonConvert.DeserializeObject<Dictionary<string, List<ProductDataJson>>>(getAllDataJson);
            switch (catalog)
            {
                case "highend":

                    var listp = db.getProductByType("SPCN");
                    listp.AddRange(db.getProductByType("SPTT"));
                    pCards = listp;
                    return View(listp);
                case "fastsale":
                    return View(db.collectRecommendProduct());
                case "face":
                    var f = db.getProductByType("SPSR");
                    f.AddRange(db.getProductByType("SPRM"));
                    return View(f);
                case "lip":
                    return View(db.getProductByType("SPSM"));
                case "showergel":
                    return View(db.getProductByType("SPST"));
                default:
                    return View();
            }
        }
        public ActionResult PriceFilter(double startPrice, double endPrice)
        {
            var getAllDataJson = System.IO.File.ReadAllText("ProductData.json");
            ViewData["ProductDataJson"] = JsonConvert.DeserializeObject<Dictionary<string, List<ProductDataJson>>>(getAllDataJson);
            foreach(var i in pCards)
            {
                Console.WriteLine("{0}-", i.giabanmoi);
            }
            if (pCards != null)return View(pCards.Where(itm => (double)itm.giabanmoi >= startPrice && (double)itm.giabanmoi <= endPrice));
            return NotFound();
        }
    }
}
