﻿using CarBook.Dto.BlogDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class BlogController : Controller
    { 
        private readonly  IHttpClientFactory _httpClientFactory;

        public BlogController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.vBreadCrumb = "Bloglar";
            ViewBag.vTitle = "Yazarlarımızın Blogları";
            var client = _httpClientFactory.CreateClient();
            var reponseMesssage = await client.GetAsync("https://localhost:7208/api/Blogs/GetAllBlogWithAuthorList");
            if (reponseMesssage.IsSuccessStatusCode)
            {
                var jsonData = await reponseMesssage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAllBlogsWithAuthorDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
