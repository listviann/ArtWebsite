using ArtWebsite.Domain.Repositories.Abstract;

namespace ArtWebsite.Domain
{
    public class DataManager
    {
        public IAuthorRepository Authors { get; set; }
        public ICategoryRepository Categories { get; set; }
        public IPaintingRepository Paintings { get; set; }
        public IPageTextFieldRepository PagesTextFields { get; set; }

        public DataManager(IAuthorRepository authors, ICategoryRepository categories,
            IPaintingRepository paintings, IPageTextFieldRepository pagesTextFields)
        {
            Authors = authors;
            Categories = categories;
            Paintings = paintings;
            PagesTextFields = pagesTextFields;
        }
    }
}
