using ArtWebsite.Domain.Entities;
using ArtWebsite.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ArtWebsite.Domain.Repositories.EntityFramework
{
    public class EFCategoryRepository : ICategoryRepository
    {
        private readonly ArtWebsiteDbContext _db;

        public EFCategoryRepository(ArtWebsiteDbContext db)
        {
            _db = db;
        }

        public void Delete(Guid id)
        {
            _db.Categories.Remove(new Category { Id = id });
            _db.SaveChanges();
        }

        public IQueryable<Category> GetCategories() => _db.Categories;

        public Category GetCategoryById(Guid id) => _db.Categories.FirstOrDefault(c => c.Id == id);

        public void Save(Category entity)
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
