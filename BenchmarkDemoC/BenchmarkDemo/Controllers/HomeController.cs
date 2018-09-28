using Microsoft.AspNetCore.Mvc;
using Services;

namespace BenchmarkDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public HomeController(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
        }

        public IActionResult Index()
        {
            ViewData["randomNumber"] = _randomNumberGenerator.GetRandomNumber();

            return View();
        }
    }
}
