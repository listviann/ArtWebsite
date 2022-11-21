using ArtWebsite.Domain.Entities;

namespace ArtWebsite.Domain.Repositories.Abstract
{
    public interface IPageTextFieldRepository
    {
        IQueryable<PageTextField> GetPagesTextFields();
        PageTextField GetPageTextFieldById(Guid id);
        PageTextField GetPageTextFieldByCodeWord(string codeWord);
        void Save(PageTextField entity);
        void Delete(Guid id);
    }
}
