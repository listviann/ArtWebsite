using System.ComponentModel.DataAnnotations;

namespace ArtWebsite.Domain.Entities
{
    public class PageTextField : BaseEntity
    {
        [Required]
        public string? CodeWord { get; set; }

        [Required]
        public string? Title { get; set; } = "Info page";

        [Required]
        public string Description { get; set; } = "The administrator adds data.";
    }
}
