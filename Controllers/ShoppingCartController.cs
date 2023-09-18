using Microsoft.AspNetCore.Mvc;

namespace WebCosmetic.Controllers
{
    public class ShoppingCartController : Controller
    {
        public IActionResult IndexSCart()
        {
            return View();
        }
    }
}
