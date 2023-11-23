using Microsoft.AspNetCore.Mvc;
using WebCosmetic.ModelBinder;
using WebCosmetic.Models;
using System.Text.Json;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace WebCosmetic.Controllers
{
    [Authorize(policy: "CusTerm")]
    public class ShoppingCartController : Controller
    {
        public IActionResult IndexCart(string productCartEncode, [FromQuery]int slmua, [FromQuery] string userid)
        {
            bool isBought = false;
            var decodeDataQuery = Encoding.UTF8.GetString(Convert.FromBase64String(productCartEncode));
            ProductCart.DetailsCart productCart = JsonConvert.DeserializeObject<ProductCart.DetailsCart>(decodeDataQuery);
            productCart.soLuongMua = slmua;
            productCart._userId = userid;
            ProductCart _productCart = new ProductCart();
            string jsonData = System.IO.File.ReadAllText("DataCart.json");
            if (!string.IsNullOrEmpty(jsonData))
            {
                var getDetails = System.Text.Json.JsonSerializer.Deserialize<ProductCart>(jsonData);
                foreach(var i in getDetails._productCart)
                {
                    if (productCart != null && i.masp == productCart.masp.Substring(0, 7))
                    {
                        isBought = true;
                        productCart.soLuongMua += i.soLuongMua;
                        continue;
                    }    
                    _productCart._productCart.Add(i);
                }
            }
            ViewData["ProductDataJson"] = JsonConvert.DeserializeObject<Dictionary<string, List<ProductDataJson>>>(System.IO.File.ReadAllText("ProductData.json"));
            
            if (productCart == null)
                return View(_productCart._productCart);
            productCart.masp = productCart.masp.Substring(0, 7);
            // Tiếp theo, kiểm tra xem productCart có giá trị không trước khi gán vào dictionary
           if(productCart != null && !string.IsNullOrEmpty(productCart.masp))
            {
                _productCart._productCart.Add(productCart);
            }
            var toJsonData = System.Text.Json.JsonSerializer.Serialize(_productCart, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            
            System.IO.File.WriteAllText("DataCart.json", toJsonData);
            // phân biệt giỏ hảng của từng user
            return View(_productCart._productCart.Where(item => item._userId == userid).ToList());
        }
    }
}
