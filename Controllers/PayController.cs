using Microsoft.AspNetCore.Mvc;

namespace WebCosmetic.Controllers
{
    public class PayController : Controller
    {
        public IActionResult IndexPay()
        {
            return View();
        }
    }
}
