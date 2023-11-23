using Microsoft.AspNetCore.Mvc;
using WebCosmetic.Models;
using System.ComponentModel.DataAnnotations;
using WebCosmetic.ModelBinder;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text;

namespace WebCosmetic.Controllers
{
    [Route("xem-chi-tiet/[action]")]
    public class DetailsController : Controller
    {
        [Route("/xem-chi-tiet/san-pham/")]
        public IActionResult IndexDetails([ModelBinder(BinderType = typeof(ProductModelBinder))] ProductCardModel productModel)
        {
            var getAllDataJson = System.IO.File.ReadAllText("ProductData.json");
            DataTransfer t = new DataTransfer();
            t.UpdateAccessTimes(productModel.masp);
            var fromJsonToObject = JsonConvert.DeserializeObject<Dictionary<string, List<ProductDataJson>>>(getAllDataJson);
            ViewData["ProductDataView"] = (from item in fromJsonToObject[productModel.masp.Substring(0, 4)]
                                           where item.masp == productModel.masp
                                          select item).Where(product => product.masp == productModel.masp).FirstOrDefault();
            ProductDetailsModel pDetails = new ProductDetailsModel(productModel);
            ViewData["ProductDataJson"] = fromJsonToObject;
            return View(pDetails);
        }
    }
}
