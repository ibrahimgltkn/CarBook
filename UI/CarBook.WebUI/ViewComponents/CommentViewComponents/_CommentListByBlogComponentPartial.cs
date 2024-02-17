using CarBook.Dto.CommentDtos;
using CarBook.Dto.TagCloudDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.BlogID = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage2 = await client.GetAsync($"https://localhost:7208/api/Comments/GetCountCommentByBlog?id=" + id);
            if (responseMessage2.IsSuccessStatusCode)
            {
                var jsondata2 = await responseMessage2.Content.ReadAsStringAsync();
                ViewBag.CommentCount = jsondata2;
            }


            var responseMessage = await client.GetAsync($"https://localhost:7208/api/Comments/CommentListByBlog?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsondata);
                return View(values);
            }



            return View();
        }
    }
}
