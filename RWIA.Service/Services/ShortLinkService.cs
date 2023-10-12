using Microsoft.Extensions.Configuration;
using RWIA.Entities;
using RWIA.Persistence.IRepositories;
using RWIA.Service.Dtos;

namespace RWIA.Service.IServices
{
    public class ShortLinkService : IShortLinkService
    {
        private readonly IShortLinkRepository _shortLinkRepository;
        private readonly IConfiguration _configuration;

        public ShortLinkService(IShortLinkRepository shortLinkRepository, IConfiguration configuration)
        {
            this._shortLinkRepository = shortLinkRepository;
            this._configuration = configuration;
        }
        public async Task<string> Generate(string url)
        {
            var shortLink = await _shortLinkRepository.Generate(url);

            return _configuration.GetSection("AppConfig:baseUrl").Value + "/" + shortLink.ShortUrl;
        }

        public async Task<ShortLinkDto?> Get(string shortUrl)
        {
            var shortLink = await _shortLinkRepository.Get(shortUrl);
            return shortLink == null ? null : new ShortLinkDto
            {
                Id = shortLink.Id,
                MainUrl = shortLink.MainUrl,
                ShortUrl = shortLink.ShortUrl,
                CreatedAt = shortLink.CreatedAt,
                ExpiredAt = shortLink.ExpiredAt
            };
        }
    }
}
