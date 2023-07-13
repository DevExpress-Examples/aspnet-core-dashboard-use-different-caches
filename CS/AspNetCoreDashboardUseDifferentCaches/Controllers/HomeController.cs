using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreDashboardUseDifferentCaches {
    public class HomeController: Controller {
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
