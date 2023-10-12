using Microsoft.AspNetCore.Mvc;
using RWIA.Service.IServices;

namespace RWIA.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShortLinkService _shortLinkService;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IShortLinkService shortLinkService, ILogger<HomeController> logger)
        {
            this._shortLinkService = shortLinkService;
            this._logger = logger;
        }

        /// <summary>
        /// Redirect to main url if the url found
        /// </summary>
        /// <param name="url">Short Url code</param>
        /// <returns></returns>
        [Route("/{url}")]
        [HttpGet]
        public async Task<IActionResult> Index([FromRoute]string url)
        {
            try
            {
                var link = await _shortLinkService.Get(url);
                if (link == null)
                    return View();

                return RedirectPermanent(link.MainUrl);

            }
            catch (Exception ex)
            {

                _logger.LogError(ex, ex.Message);
                return View("Error");
            }
        }
    }
}
