using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewData["HistoryProduct"] = transfer.GetProductHistory(khId);
            return View(getDetails._billHistoryList);
        }
    }
}
