using ArtWebsite.Domain.Entities;
using ArtWebsite.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

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

        public Painting GetPaintingById(Guid id) => _db.Paintings.FirstOrDefault(p => p.Id == id);

        public IQueryable<Painting> GetPaintings() => _db.Paintings;

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
