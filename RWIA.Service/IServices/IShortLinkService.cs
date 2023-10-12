using RWIA.Service.Dtos;

namespace RWIA.Service.IServices
{
    public interface IShortLinkService 
    {
        Task<string> Generate(string url);
        Task<ShortLinkDto?> Get(string shortUrl);
    }
}
