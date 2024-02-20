using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.DashboardComponents
{
    public class _AdminDashboardStatisticComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region //CarCount
            var responseMessage = await client.GetAsync("https://localhost:7208/api/Statistics/GetCarCount");
            if (responseMessage.IsSuccessStatusCode)
            {
                int randomCount = random.Next(0, 101);
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.CarCount = values.CarCount;
                ViewBag.CarCountRandom = randomCount;
            }
            #endregion

            #region //LocationCount
            var responseMessage2 = await client.GetAsync("https://localhost:7208/api/Statistics/GetLocationCount");
            if (responseMessage2.IsSuccessStatusCode)
            {
                int LocationCountRandom = random.Next(0, 101);
                var jsonData2 = await responseMessage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.LocationCount = values2.LocationCount;
                ViewBag.LocationCountRandom = LocationCountRandom;
            }
            #endregion

            #region //BrandCount
            var responseMessage5 = await client.GetAsync("https://localhost:7208/api/Statistics/GetBrandCount");
            if (responseMessage5.IsSuccessStatusCode)
            {
                int BrandCountRandom = random.Next(0, 101);
                var jsonData5 = await responseMessage5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.BrandCount = values5.BrandCount;
                ViewBag.BrandCountRandom = BrandCountRandom;
            }
            #endregion

            #region //AvgRentPrizeForDaily
            var responseMessage6 = await client.GetAsync("https://localhost:7208/api/Statistics/GetAvgRentPrizeForDaily");
            if (responseMessage6.IsSuccessStatusCode)
            {
                int AvgRentPrizeForDailyRandom = random.Next(0, 101);
                var jsonData6 = await responseMessage6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.AvgRentPrizeForDaily = values6.avgPriceForDaily.ToString("0.00");
                ViewBag.AvgRentPrizeForDailyRandom = AvgRentPrizeForDailyRandom;
            }
            #endregion

            return View();
        }
    }
}
