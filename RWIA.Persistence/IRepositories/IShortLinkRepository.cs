using RWIA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RWIA.Persistence.IRepositories
{
    public interface IShortLinkRepository
    {
        Task<ShortLink> Generate(string url);
        Task<ShortLink?> Get(string shortUrl);
    }
}
