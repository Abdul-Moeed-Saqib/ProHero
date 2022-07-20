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
            ViewBag.total = cart.Sum(c => c.Charity.Donated);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(float donated, long charityId)
        {
            var charityItem = new CharityItem();
            var charity = await charityRepo.GetCharityById(charityId.ToString());
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                var newCart = new List<ShoppingCart>();
                AddingToCart(donated, charityItem, charity, newCart);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", newCart);

            }
            else
            {
                if (IsExist(charityId, cart))
                {
                    var index = cart.FindIndex(i => i.Charity.Charity.CharityId == charityId);

                    cart[index].Charity.DonatedStack.Add(donated);
                    cart[index].Charity.Donated += donated;
                    cart[index].Quantity++;
                }
                else
                {
                    AddingToCart(donated, charityItem, charity, cart);
                }

                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);
            }

            return RedirectToAction("ViewCart");
        }

        public IActionResult Remove(long charityId)
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");
            var index = cart.FindIndex(i => i.Charity.Charity.CharityId == charityId);

            if (cart[index].Quantity > 1)
            {
                var lastDonation = cart[index].Charity.DonatedStack.Last();
                cart[index].Quantity--;
                cart[index].Charity.Donated -= lastDonation;
                cart[index].Charity.DonatedStack.Remove(lastDonation);
            }
            else
            {
                cart.RemoveAt(index);
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", cart);

            return RedirectToAction("ViewCart");
        }

        private static void AddingToCart(float donated, CharityItem charityItem, Charity charity, List<ShoppingCart> cart)
        {
            charityItem.Charity = charity;
            charityItem.Donated += donated;

            cart.Add(new ShoppingCart() { Charity = charityItem, Quantity = 1 });
        }

        private bool IsExist(long charityId, List<ShoppingCart> cart)
        {
            return cart.Any(i => i.Charity.Charity.CharityId == charityId);
        }
    }
}
