using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.ViewComponents.RentACarFilterComponents
{
    public class _RentACarFilterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
             v = "deneme";
            TempData["Value"] = v;
            return View();
        }
    }
}
