using CarBook.Dto.CarDescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailDescriptionComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailDescriptionComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.CarID = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7208/api/CarDescriptions/CarDescriptionByCarId?id={id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarDescriptionByCarIdDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
