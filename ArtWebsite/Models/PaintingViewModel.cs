namespace ArtWebsite.Models
{
    public class PaintingViewModel
    {
        public Guid PaintingId { get; set; }
        public string? PaintingTitle { get; set; }
        public string? PaintingImagePath { get; set; }
        public string? PaintingAuthorName { get; set; }
        public string? PaintingCategoryName { get; set; }
        public DateTime PaintingDateCreated { get; set; }
    }
}
