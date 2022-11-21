using ArtWebsite.Domain.Entities;

namespace ArtWebsite.Domain.Repositories.Abstract
{
    public interface IAuthorRepository
    {
        IQueryable<Author> GetAuthors();
        Author GetAuthorById(Guid id);
        void Save(Author entity);
        void Delete(Guid id);
    }
}
