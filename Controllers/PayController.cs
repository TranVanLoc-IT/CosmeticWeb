using Microsoft.AspNetCore.Mvc;
using WebCosmetic.Models;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System;
using System.Text.Json;

namespace WebCosmetic.Controllers
{
    public class PayController : Controller
    {
        DataTransfer transfer = new DataTransfer();
        [HttpPost]
        public ActionResult PayingProcess([FromForm]PayingModel paying)
        {
            if(ModelState.IsValid)
            {
                string mahd = transfer.addBillAndPayment(paying);
                if (!string.IsNullOrEmpty(mahd))
                {
                    SuccessPayingModel ps = new SuccessPayingModel();
                    ps._khId = paying._makh;
                    ps._clientInfo._clienName = paying._tenkh;
                    ps._clientInfo._clientAddress = paying._address;
                    ps._clientInfo._phone = paying._phone;
                    ps._bill = transfer.GetBillInfoLatest(paying._makh, mahd);
                    ps._bill._totalMoney = paying._totalMoney;
                    RemoveCart(paying);
                    AddToHistory(ps);
                    return View(model: ps);
                }
            }    
            ViewBag.ProcessError = "Thực hiện giao dịch thất bại!!";
            ViewData["payState"] = "Lỗi giao dịch";
            return View();
        }
        private void AddToHistory(SuccessPayingModel success)
        {
            HistoryUserBill history = new HistoryUserBill();
            string jsonData = System.IO.File.ReadAllText("BillHistory.json");
            if (!string.IsNullOrEmpty(jsonData))
            {
                var getDetails = System.Text.Json.JsonSerializer.Deserialize<HistoryUserBill>(jsonData);
                foreach (var i in getDetails._billHistoryList)
                {
                    history._billHistoryList.Add(i);
                }
                
            }
            if (success != null)
            {
                history._billHistoryList.Add(success);
            }
            var toJsonData = System.Text.Json.JsonSerializer.Serialize(history, new JsonSerializerOptions()
            {
                WriteIndented = true
            });
            System.IO.File.WriteAllText("BillHistory.json", toJsonData);
        }
        private void RemoveCart(PayingModel paying)
        {
            ProductCart _productCart = new ProductCart();
            string jsonData = System.IO.File.ReadAllText("DataCart.json");
            if (!string.IsNullOrEmpty(jsonData))
            {
                var getDetails = System.Text.Json.JsonSerializer.Deserialize<ProductCart>(jsonData);
                Func<Dictionary<string, int>, string, bool> regex = (items, value) =>
                 {
                     foreach (var key in items.Keys)
                     {
                         if (key == value)
                         {
                             return true;
                         }
                     }
                     return false;
                 };
                // nếu đó là sp ko nằm trong mục thanh toán thì add
                foreach (var i in getDetails._productCart)
                {
                    if(!regex(paying._sanphamMua,i.masp) && paying._makh.Contains(i._userId.Substring(0, 5)))
                    {
                        _productCart._productCart.Add(i);
                    }
                }

                var toJsonData = System.Text.Json.JsonSerializer.Serialize(_productCart, new JsonSerializerOptions()
                {
                    WriteIndented = true
                });

                System.IO.File.WriteAllText("DataCart.json", toJsonData);
            }
        }
        public IActionResult IndexPay(string buyList)
        {
            List<ProductCart.DetailsCart> productCart = JsonConvert.DeserializeObject<List<ProductCart.DetailsCart>>(buyList);
            ViewBag.productCart = productCart;
            return View(new PayingModel());
        }
    }
}
