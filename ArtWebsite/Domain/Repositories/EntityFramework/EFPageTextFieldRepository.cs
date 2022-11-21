using ArtWebsite.Domain.Entities;
using ArtWebsite.Domain.Repositories.Abstract;
using Microsoft.EntityFrameworkCore;

namespace ArtWebsite.Domain.Repositories.EntityFramework
{
    public class EFPageTextFieldRepository : IPageTextFieldRepository
    {
        private readonly ArtWebsiteDbContext _db;

        public EFPageTextFieldRepository(ArtWebsiteDbContext db)
        {
            _db = db;
        }

        public void Delete(Guid id)
        {
            _db.PagesTextFields.Remove(new PageTextField { Id = id });
            _db.SaveChanges();
        }

        public IQueryable<PageTextField> GetPagesTextFields() => _db.PagesTextFields;

        public PageTextField GetPageTextFieldById(Guid id) => _db.PagesTextFields.FirstOrDefault(p => p.Id == id);

        public PageTextField GetPageTextFieldByCodeWord(string codeWord) => _db.PagesTextFields.FirstOrDefault(p => p.CodeWord == codeWord);

        public void Save(PageTextField entity)
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
