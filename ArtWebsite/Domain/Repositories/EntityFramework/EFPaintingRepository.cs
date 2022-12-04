using ArtWebsite.Domain.Entities;
using ArtWebsite.Domain.Repositories.Abstract;
using ArtWebsite.Models;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;

namespace ArtWebsite.Domain.Repositories.EntityFramework
{
    public class EFPaintingRepository : IPaintingRepository
    {
        private readonly ArtWebsiteDbContext _db;

        public EFPaintingRepository(ArtWebsiteDbContext db)
        {
            _db = db;
        }

        public void Delete(Guid id)
        {
            _db.Paintings.Remove(new Painting { Id = id });
            _db.SaveChanges();
        }

        public Painting GetPaintingById(Guid id)
        {
            return _db.Paintings.Include(p => p.Author).Include(p => p.Category).FirstOrDefault(p => p.Id == id);
        }

        public List<PaintingViewModel> GetPaintingModels()
        {
            return _db.Paintings
                .Select(x => new PaintingViewModel
                {
                    PaintingId = x.Id,
                    PaintingTitle = x.Title,
                    PaintingImagePath = x.ImagePath,
                    PaintingAuthorName = x.Author!.Name,
                    PaintingCategoryName = x.Category!.Name,
                    PaintingDateCreated = x.DateCreated
                }).ToList();
        }

        public IQueryable<Painting> GetPaintings() => _db.Paintings.Include(p => p.Author).Include(p => p.Category);

        public void Save(Painting entity)
        {
            if (entity.Id == default)
            {
                _db.Entry(entity).State = EntityState.Added;
            }
            else
            {
                _db.Entry(entity).State = EntityState.Modified;
            }

            _db.SaveChanges();
        }
    }
}
