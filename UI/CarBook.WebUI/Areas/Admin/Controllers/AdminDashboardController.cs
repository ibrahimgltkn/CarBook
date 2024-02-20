using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Route("/Admin/AdminDashboard")]
    [Area("Admin")]
    public class AdminDashboardController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
