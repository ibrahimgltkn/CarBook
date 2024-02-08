using CarBook.Dto.BrandDtos;
using CarBook.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace CarBook.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Cars/GetCarWithBrand");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDtos>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Brands/");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                List<SelectListItem> brandValues = (from x in values 
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandID.ToString()
                                                    }).ToList();
                ViewBag.Brand = brandValues;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCar( ResultCreateCarDto resultCreateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultCreateCarDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7208/api/Cars",content);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7208/api/Cars/{id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage1 = await client.GetAsync("https://localhost:7208/api/Brands/");
            if (responseMessage1.IsSuccessStatusCode)
            {
                var jsonData1 = await responseMessage1.Content.ReadAsStringAsync();
                var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
                List<SelectListItem> brandValues = (from x in values1
                                                    select new SelectListItem
                                                    {
                                                        Text = x.Name,
                                                        Value = x.BrandID.ToString()
                                                    }).ToList();
                ViewBag.Brand = brandValues;
            }

            var responseMessage = await client.GetAsync($"https://localhost:7208/api/Cars/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultUpdateCarDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCar(ResultUpdateCarDto resultUpdateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(resultUpdateCarDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8,"application/json");
            var responseMessage = await client.PutAsync("https://localhost:7208/api/Cars/", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
