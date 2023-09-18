using Microsoft.AspNetCore.Mvc;

namespace WebCosmetic.Controllers
{
    public class CatalogController : Controller
    {
        public IActionResult IndexCatalog()
        {
            return View();
        }
    }
}
