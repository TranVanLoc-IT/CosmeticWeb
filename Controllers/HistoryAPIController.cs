using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebCosmetic.Models;

namespace WebCosmetic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryAPIController : ControllerBase
    {
        DataTransfer transfer = new DataTransfer();
        [HttpGet]
        public List<SuccessPayingModel> Get()
        {
            string jsonData = System.IO.File.ReadAllText("BillHistory.json");
            var getDetails = System.Text.Json.JsonSerializer.Deserialize<HistoryUserBill>(jsonData);
            return getDetails._billHistoryList;
        }
    }
}
