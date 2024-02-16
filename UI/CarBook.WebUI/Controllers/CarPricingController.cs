using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.vBreadCrumb = "Paketler";
            ViewBag.vTitle = "Araç Fiyat Paketleri";
            return View();
        }
    }
}
