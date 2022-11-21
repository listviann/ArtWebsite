using ArtWebsite.Domain.Entities;
using ArtWebsite.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ArtWebsite.Domain.Repositories.EntityFramework
{
    public class EFAuthorRepository : IAuthorRepository
    {
        private readonly ArtWebsiteDbContext _db;

        public EFAuthorRepository(ArtWebsiteDbContext db)
        {
            _db = db;
        }

        public void Delete(Guid id)
        {
            _db.Authors.Remove(new Author { Id = id });
            _db.SaveChanges();
        }

        public Author GetAuthorById(Guid id) => _db.Authors.FirstOrDefault(a => a.Id == id);

        public IQueryable<Author> GetAuthors() => _db.Authors;

        public void Save(Author entity)
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
