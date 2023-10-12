using System.ComponentModel.DataAnnotations;

namespace RWIA.Entities
{
    public class ShortLink
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
        public ShortLink()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.Now;
            ExpiredAt = DateTime.Now.AddDays(30);
        }
    }
}
