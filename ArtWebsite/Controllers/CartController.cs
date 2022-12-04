using ArtWebsite.Domain;
using ArtWebsite.Domain.Entities;
using ArtWebsite.Service;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging.Abstractions;
using System.Collections.Immutable;
using System.Diagnostics;
using Microsoft.AspNetCore.Components.Web;
using ArtWebsite.Models;
using System.Net.Http.Headers;

namespace ArtWebsite.Controllers
{
    public class CartController : Controller
    {
        private readonly DataManager _dataManager;

        public CartController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult AddToCart(Guid id)
        {
            Debug.WriteLine(id);
            var paintings = _dataManager.Paintings.GetPaintingModels();
            //Debug.WriteLine(paintings.FirstOrDefault(p => p.PaintingId == id).PaintingTitle);

            if (SessionHelper.GetObjectFromJson<List<CartViewModel>>(HttpContext.Session, "cart") == null)
            {
                List<CartViewModel> cart = new()
                {
                    new CartViewModel { Painting = paintings.FirstOrDefault(p => p.PaintingId == id), Quantity = 1 }
                };
                
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
                
            }
            else
            {
                List<CartViewModel> cart = SessionHelper.GetObjectFromJson<List<CartViewModel>>(HttpContext.Session, "cart");
                int index = IsExist(id);
                if (index != -1)
                {
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new CartViewModel { Painting = paintings.FirstOrDefault(p => p.PaintingId == id), Quantity = 1 });
                }
                
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction(nameof(PaintingsController.Index), nameof(PaintingsController).CutController());
        }

        private int IsExist(Guid id)
        {
            List<CartViewModel> cart = SessionHelper.GetObjectFromJson<List<CartViewModel>>(HttpContext.Session, "cart");
            for (int i = 0; i < cart.Count; i++)
            {
                if (cart[i].Painting.PaintingId.Equals(id))
                {
                    return i;
                }
            }

            return -1;
        }

        public IActionResult Index()
        {
            var cart = SessionHelper.GetObjectFromJson<List<CartViewModel>>(HttpContext.Session, "cart");
            return View(cart);
        }

        public IActionResult Remove(Guid id)
        {
            List<CartViewModel> cart = SessionHelper.GetObjectFromJson<List<CartViewModel>>(HttpContext.Session, "cart");
            int index = IsExist(id);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction(nameof(CartController.Index), nameof(CartController).CutController());
        }
    }
}
