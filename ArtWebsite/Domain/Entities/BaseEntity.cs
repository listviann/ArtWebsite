using System.ComponentModel.DataAnnotations;

namespace ArtWebsite.Domain.Entities
{
    public class BaseEntity
    {
        [Required]
        public Guid Id { get; set; }

        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }

        protected BaseEntity() => DateAdded = DateTime.Now;
    }
}
