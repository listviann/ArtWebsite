using System.ComponentModel.DataAnnotations;

namespace ArtWebsite.Domain.Entities
{
    public class Author : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string? Name { get; set; }

        [Required]
        [StringLength(500)]
        public string? Description { get; set; }

        public DateTime BirthDate { get; set; }
        public List<Painting> Paintings { get; set; } = new();
    }
}
