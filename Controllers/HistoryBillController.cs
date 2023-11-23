using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebCosmetic.Models;

namespace WebCosmetic.Controllers
{
    public class HistoryBillController : Controller
    {
        public IActionResult HistoryBill(string khId)
        {
            DataTransfer transfer = new DataTransfer();
            string jsonData = System.IO.File.ReadAllText("BillHistory.json");
            var getDetails = System.Text.Json.JsonSerializer.Deserialize<HistoryUserBill>(jsonData);
            var products = transfer.GetProductHistory(khId);
            ViewData["HistoryProduct"] = products;
            return View(getDetails._billHistoryList);
        }
    }
}
