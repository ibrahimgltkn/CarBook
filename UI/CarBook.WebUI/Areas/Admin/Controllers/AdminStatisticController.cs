using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Route("/Admin/AdminStatistic")]
    [Area("Admin")]
    public class AdminStatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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
                ViewBag.RandomCount = randomCount;
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

            #region //AuthorCount
            var responseMessage3 = await client.GetAsync("https://localhost:7208/api/Statistics/GetAuthorCount");
            if (responseMessage3.IsSuccessStatusCode)
            {
                int AuthorCountRandom = random.Next(0, 101);
                var jsonData3 = await responseMessage3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.AuthorCount = values3.AuthorCount;
                ViewBag.AuthorCountRandom = AuthorCountRandom;
            }
            #endregion

            #region //BlogCount
            var responseMessage4 = await client.GetAsync("https://localhost:7208/api/Statistics/GetBlogCount");
            if (responseMessage4.IsSuccessStatusCode)
            {
                int BlogCountRandom = random.Next(0, 101);
                var jsonData4 = await responseMessage4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.BlogCount = values4.BlogCount;
                ViewBag.BlogCountRandom = BlogCountRandom;
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

            #region //AvgRentPrizeForWeekly
            var responseMessage7 = await client.GetAsync("https://localhost:7208/api/Statistics/GetAvgRentPrizeForWeekly");
            if (responseMessage7.IsSuccessStatusCode)
            {
                int AvgRentPrizeForWeeklyRandom = random.Next(0, 101);
                var jsonData7 = await responseMessage7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.AvgRentPrizeForWeekly = values7.avgPriceForWeekly.ToString("0.00");
                ViewBag.AvgRentPrizeForWeeklyRandom = AvgRentPrizeForWeeklyRandom;
            }
            #endregion avgPriceForWeekly

            #region //AvgRentPrizeForMonthly
            var responseMessage8 = await client.GetAsync("https://localhost:7208/api/Statistics/GetAvgRentPrizeForMonthly");
            if (responseMessage8.IsSuccessStatusCode)
            {
                int AvgRentPrizeForMonthlyRandom = random.Next(0, 101);
                var jsonData8 = await responseMessage8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.AvgRentPrizeForMonthly = values8.avgPriceForMonthly.ToString("0.00");
                ViewBag.AvgRentPrizeForMonthlyRandom = AvgRentPrizeForMonthlyRandom;
            }
            #endregion avgPriceForMonthly

            #region //CarCountByTransmissionIsAuto
            var responseMessage9 = await client.GetAsync("https://localhost:7208/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMessage9.IsSuccessStatusCode)
            {
                int carCountByTransmissionIsAutoRandom = random.Next(0, 101);
                var jsonData9 = await responseMessage9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.carCountByTransmissionIsAuto = values9.carCountByTransmissionIsAuto;
                ViewBag.carCountByTransmissionIsAutoRandom = carCountByTransmissionIsAutoRandom;
            }
            #endregion CarCountByTransmissionIsAuto

            #region //CarCountByTransmissionIsAuto
            var responseMessage10 = await client.GetAsync("https://localhost:7208/api/Statistics/GetCarCountBySmallerThan1000");
            if (responseMessage10.IsSuccessStatusCode)
            {
                int carCountBySmallerThan1000Random = random.Next(0, 101);
                var jsonData10 = await responseMessage10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.carCountBySmallerThan1000 = values10.carCountBySmallerThan1000;
                ViewBag.carCountBySmallerThan1000Random = carCountBySmallerThan1000Random;
            }
            #endregion CarCountByTransmissionIsAuto

            #region //carCountByFuelGasolineOrDiesel
            var responseMessage11 = await client.GetAsync("https://localhost:7208/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMessage11.IsSuccessStatusCode)
            {
                int carCountByFuelGasolineOrDieselRandom = random.Next(0, 101);
                var jsonData11 = await responseMessage11.Content.ReadAsStringAsync();
                var values11 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData11);
                ViewBag.carCountByFuelGasolineOrDiesel = values11.carCountByFuelGasolineOrDiesel;
                ViewBag.carCountByFuelGasolineOrDieselRandom = carCountByFuelGasolineOrDieselRandom;
            }
            #endregion carCountByFuelGasolineOrDiesel

            #region //carCountByFuelElectric
            var responseMessage12 = await client.GetAsync("https://localhost:7208/api/Statistics/GetCarCountByFuelElectric");
            if (responseMessage12.IsSuccessStatusCode)
            {
                int carCountByFuelElectricRandom = random.Next(0, 101);
                var jsonData12 = await responseMessage12.Content.ReadAsStringAsync();
                var values12 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData12);
                ViewBag.carCountByFuelElectric = values12.carCountByFuelElectric;
                ViewBag.carCountByFuelElectricRandom = carCountByFuelElectricRandom;
            }
            # endregion carCountByFuelElectric


            return View();
        }
    }
}
