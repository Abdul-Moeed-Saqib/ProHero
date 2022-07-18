using Microsoft.AspNetCore.Mvc;
using ProHeroWeb.Helpers;
using ProHeroWeb.Models;
using ProHeroWeb.Services;

namespace ProHeroWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ICharityRepo charityRepo;

        public CartController(ICharityRepo charityRepo)
        {
            this.charityRepo = charityRepo;
        }

        public IActionResult ViewCart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");
            if (cart == null)
            {
                cart = new List<ShoppingCart>();
            }
            ViewBag.Cart = cart;
            ViewBag.total = cart.Sum(c => c.Charity.Donated * c.Quantity);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(float donated, long charityId)
        {
            var charityItem = new CharityItem();
            var charity = await charityRepo.GetCharityById(charityId.ToString());

            if (SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart") == null)
            {
                var cart = new List<ShoppingCart>();

                charityItem.Charity = charity;
                charityItem.Donated += donated;
                cart.Add(new ShoppingCart() { Charity = charityItem, Quantity = 1 });
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            }
            else
            {
                var cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");

                if (IsExist(charityId))
                {
                    var index = cart.FindIndex(i => i.Charity.Charity.CharityId == charityId);
                    cart[index].Quantity++;
                }
                else
                {
                    cart.Add(new ShoppingCart() { Charity = charityItem, Quantity = 1});
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("ViewCart");
        }

        public IActionResult Remove(long charityId)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");
            var index = cart.FindIndex(i => i.Charity.Charity.CharityId == charityId);
            cart.RemoveAt(index);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("ViewCart");
        }

        private bool IsExist(long charityId)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");

            return cart.Any(i => i.Charity.Charity.CharityId == charityId);
        }
    }
}
