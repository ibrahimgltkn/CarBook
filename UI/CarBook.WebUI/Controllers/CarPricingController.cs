using CarBook.Dto.BlogDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using X.PagedList;

namespace CarBook.WebUI.Controllers
{
    public class CarPricingController : Controller
    {
		private readonly IHttpClientFactory _httpClientFactory;

		public CarPricingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IActionResult> Index(int page = 1)
        {
            ViewBag.vBreadCrumb = "Paketler";
            ViewBag.vTitle = "Araç Fiyat Paketleri";
			var client = _httpClientFactory.CreateClient();
			var reponseMesssage = await client.GetAsync("https://localhost:7208/api/CarPricings/GetCarPricingWithTimePeriod");
			if (reponseMesssage.IsSuccessStatusCode)
			{
				var jsonData = await reponseMesssage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData).ToPagedList(page,10);
				return View(values);
			}
			return View();
        }
    }
}
