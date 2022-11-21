using Microsoft.AspNetCore.Mvc;
using ArtWebsite.Domain;

namespace ArtWebsite.Models.ViewComponents
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly DataManager _dataManager;
        
        public SidebarViewComponent(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public Task<IViewComponentResult> InvokeAsync()
        {
            return Task.FromResult((IViewComponentResult) View("Default", _dataManager.Paintings.GetPaintings()));
        }
    }
}
