using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.vBreadCrumb = "Hizmetler";
            ViewBag.vTitle = "Hizmetlerimiz";
            return View();
        }
    }
}
