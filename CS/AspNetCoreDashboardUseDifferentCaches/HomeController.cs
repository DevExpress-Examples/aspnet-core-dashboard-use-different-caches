using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspNetCoreDashboardUseDifferentCaches
{
    public class HomeController: Controller
    {
        // GET: /<controller>/
        public IActionResult Index() {
            return View();
        }
        public IActionResult Refresh([FromServices]CacheManager cacheManager) {
            cacheManager.ResetCache();
            return Ok();
        }
    }
}
