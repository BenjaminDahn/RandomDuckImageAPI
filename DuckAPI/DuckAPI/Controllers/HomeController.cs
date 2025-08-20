using DuckAPI.Models;
using DuckAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DuckAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly DuckAPIService _duckAPIService;

        public HomeController(DuckAPIService duckAPIService)
        {
            _duckAPIService = duckAPIService;
        }

        public async Task<IActionResult> Index()
        {
            var home = await _duckAPIService.GetResponseAsync();
            return View(home);
        }
    }
}
