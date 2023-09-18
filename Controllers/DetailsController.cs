using Microsoft.AspNetCore.Mvc;

namespace WebCosmetic.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult IndexDetails()
        {
            return View();
        }
    }
}
