using System.ComponentModel.DataAnnotations;

namespace ArtWebsite.Domain.Entities
{
    public class Painting : BaseEntity
    {
        [Required]
        [StringLength(150)]
        public string? Title { get; set; }

        public string? ImagePath { get; set; }
        public DateTime DateCreated { get; set; }

        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }

        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
