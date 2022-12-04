using ArtWebsite.Domain.Entities;
using ArtWebsite.Models;

namespace ArtWebsite.Domain.Repositories.Abstract
{
    public interface IPaintingRepository
    {
        IQueryable<Painting> GetPaintings(); 
        Painting GetPaintingById(Guid id);
        List<PaintingViewModel> GetPaintingModels();
        void Save(Painting entity); 
        void Delete(Guid id);
    }
}
