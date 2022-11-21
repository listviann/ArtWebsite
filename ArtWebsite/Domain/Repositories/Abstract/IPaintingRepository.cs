using ArtWebsite.Domain.Entities;

namespace ArtWebsite.Domain.Repositories.Abstract
{
    public interface IPaintingRepository
    {
        IQueryable<Painting> GetPaintings(); 
        Painting GetPaintingById(Guid id); 
        void Save(Painting entity); 
        void Delete(Guid id);
    }
}
