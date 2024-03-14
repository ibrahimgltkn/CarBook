using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public CarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.vBreadCrumb = "Araçlarımız";
            ViewBag.vTitle = "Aracınızı Seçiniz";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/CarPricings");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData).ToPagedList(page,1);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.vBreadCrumb = "Araç Detayları";
            ViewBag.vTitle = "Aracın Teknik Aksesuar ve Özellikleri";
            ViewBag.CarID = id;

			return View();
        }
    }
}
