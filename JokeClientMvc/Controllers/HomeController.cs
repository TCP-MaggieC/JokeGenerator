using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using JokeClientMvc.Models;

namespace JokeClientMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<JokeCategoryModel> categoryList = new List<JokeCategoryModel>();
            JokeCategoryModel animal = new JokeCategoryModel();
            animal.JokeCategory = "animal";
            categoryList.Add(animal);

            JokeCategoryModel career = new JokeCategoryModel();
            career.JokeCategory = "career";
            categoryList.Add(career);

            JokeCategoryModel food = new JokeCategoryModel();
            food.JokeCategory = "food";
            categoryList.Add(food);


            //todo: gRPC call JokeService getCategories()
            return View(categoryList);
        }

        public IActionResult Privacy()
        {
            
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
