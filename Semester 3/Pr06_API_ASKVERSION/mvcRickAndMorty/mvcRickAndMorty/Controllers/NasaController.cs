using Microsoft.AspNetCore.Mvc;
using mvcRickAndMorty.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace mvcRickAndMorty.Controllers
{
    public class NasaController : Controller
    {
        private const string APIKEY = "6dly8NqrXOsgteSo4YTSLsGQ5KfO2ZPGNvrlm3lX";
        private const string BASE_URL = "https://api.nasa.gov/planetary/apod?api_key=";

        private readonly NasaHttpService _nasaHttpService;

        public NasaController(NasaHttpService nasaHttpService)
        {
            _nasaHttpService = nasaHttpService;
        }

        public async Task<IActionResult> Index(string date, string startDate, string endDate, string dateType)
        {
            List<string> imageUrls = new List<string>();

            if (dateType == "single" && !string.IsNullOrEmpty(date))
            {
                string endpoint = $"{BASE_URL}{APIKEY}&date={date}";
                List<string> img = await _nasaHttpService.GetDailyImage(new HttpClient(), endpoint);
                foreach (var imga in img)
                {
                    imageUrls.Add(imga);
                }
            }
            else if (dateType == "range" && !string.IsNullOrEmpty(startDate) && !string.IsNullOrEmpty(endDate))
            {
                DateTime start = DateTime.Parse(startDate);
                DateTime end = DateTime.Parse(endDate);

                for (var currentDate = start; currentDate <= end; currentDate = currentDate.AddDays(1))
                {
                    string endpoint = $"{BASE_URL}{APIKEY}&date={currentDate:yyyy-MM-dd}";
                    List<string> img = await _nasaHttpService.GetDailyImage(new HttpClient(), endpoint);
                    foreach (var imga in img)
                    {
                        imageUrls.Add(imga);
                    }
                }
            }


            ViewBag.ImageUrls = imageUrls;
            if (imageUrls.Count == 0)
            {
                string endpoint = $"{BASE_URL}{APIKEY}";
                List<string> img = await _nasaHttpService.GetDailyImage(new HttpClient(), endpoint);
                foreach (var imga in img)
                {
                    imageUrls.Add(imga);
                }
            }

            ViewBag.SelectedDate = date;
            ViewBag.StartDate = startDate;
            ViewBag.EndDate = endDate;
            ViewBag.DateType = dateType;

            return View();
        }
    }
}
