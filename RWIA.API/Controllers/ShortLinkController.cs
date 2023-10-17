using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RWIA.Service.Dtos;
using RWIA.Service.IServices;
using System;

namespace RWIA.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShortLinkController : ControllerBase
    {
        private readonly ILogger<ShortLinkController> _logger;
        private readonly IShortLinkService _shortLinkService;

        public ShortLinkController(ILogger<ShortLinkController> logger, IShortLinkService shortLinkRepository)
        {
            this._logger = logger;
            this._shortLinkService = shortLinkRepository;
        }

        /// <summary>
        /// Get Url info by the short url code
        /// </summary>
        /// <param name="shortUrl">Code</param>
        /// <returns></returns>
        [HttpGet("{urlCode}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ShortLinkDto>> GetAsync([FromRoute] string urlCode)
        {
            try
            {
                return Ok(await _shortLinkService.Get(urlCode));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }

        /// <summary>
        /// Generate short url by the main url
        /// </summary>
        /// <param name="url">Main Url</param>
        /// <returns>Short Url</returns>
        [HttpPost("generate")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<string>> GenerateAsync([FromBody]string url)
        {
            try
            {
                return Ok(await _shortLinkService.Generate(url));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return StatusCode(500, "Something went wrong.");
            }
        }
    }
}
