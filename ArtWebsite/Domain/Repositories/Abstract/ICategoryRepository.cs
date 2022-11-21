using ArtWebsite.Domain.Entities;

namespace ArtWebsite.Domain.Repositories.Abstract
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetCategories();
        Category GetCategoryById(Guid id);
        void Save(Category entity);
        void Delete(Guid id);
    }
}
