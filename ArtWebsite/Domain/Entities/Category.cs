using System.ComponentModel.DataAnnotations;

namespace ArtWebsite.Domain.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }

        public List<Painting> Paintings { get; set; } = new();
    }
}
