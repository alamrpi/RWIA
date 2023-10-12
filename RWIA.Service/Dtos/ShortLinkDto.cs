using System.ComponentModel.DataAnnotations;

namespace RWIA.Service.Dtos
{
    public class ShortLinkDto
    {
        public Guid Id { get; set; }

        [Required]
        public string MainUrl { get; set; }

        [Required]
        public string ShortUrl { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ExpiredAt { get; set; }
    }
}
