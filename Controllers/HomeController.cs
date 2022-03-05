using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Nest;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ElasticClient _client;
        private  IMemoryCache _memoryCache;
        private readonly BookConsumer _consumer;

        public HomeController(ILogger<HomeController> logger, ElasticClient client, IMemoryCache memoryCache, BookConsumer consumer)
        {
            _logger = logger;
            _client = client;
            _memoryCache = memoryCache;
            _consumer = consumer;
        }

        public async Task<IActionResult> Index(string query)
        {
            BookViewModel model = new BookViewModel();
            if (!string.IsNullOrEmpty(query))
            {
                model.Books = await _consumer.GetAllOwners(query);
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
