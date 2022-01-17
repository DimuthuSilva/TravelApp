using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TravelApp.Web.Models;
using TravelApp.Web.Services;

namespace TravelApp.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApiService _apiService;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="apiService">The API service.</param>
        public HomeController(ILogger<HomeController> logger, ApiService apiService)
        {
            _logger = logger;
            _apiService = apiService;
        }

        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the search results.
        /// </summary>
        /// <param name="searchModel">The search model.</param>
        /// <returns></returns>
        public async Task<JsonResult> GetSearchResults(SearchModel searchModel)
        {
            var list = await _apiService.GetTravelDetailsAsync(searchModel);
            return Json(list);
        }

        /// <summary>
        /// Gets the transport types.
        /// </summary>
        /// <returns></returns>
        public async Task<JsonResult> GetTransportTypes()
        {
            var list = await _apiService.GetTransportTypesAsync();
            return Json(list);
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
