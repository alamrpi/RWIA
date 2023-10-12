using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RWIA.Entities;
using RWIA.Persistence.Context;
using RWIA.Persistence.IRepositories;
using RWIA.Utility.Helpers;

namespace RWIA.Persistence.Repositories
{
    public class ShortLinkRepository : IShortLinkRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ShortLinkRepository(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<ShortLink> Generate(string url)
        {
            var shortLink = new ShortLink()
            {
                MainUrl = url,
                ShortUrl = getShortUrl(4),
            };

            await _dbContext.ShortLinks.AddAsync(shortLink);
            await _dbContext.SaveChangesAsync();

            return shortLink;
        }

        public async Task<ShortLink?> Get(string shortUrl)
        {
            return await _dbContext.ShortLinks
                .Where(x => x.ShortUrl.Contains(shortUrl))
                .Where(x => x.ExpiredAt >= DateTime.Now)
                .FirstOrDefaultAsync();
        }

        private string getShortUrl(int lenght)
        {
            var url = RandomString.Generate(lenght).ToLower();
            if (_dbContext.ShortLinks.Where(s => s.ShortUrl == url).Any())
                getShortUrl(lenght + 1);
   
            return url;
        }
    }
}
