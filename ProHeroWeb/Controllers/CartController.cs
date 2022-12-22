using Microsoft.AspNetCore.Mvc;
using ProHeroWeb.Helpers;
using ProHeroWeb.Models;
using ProHeroWeb.Services;

namespace ProHeroWeb.Controllers
{
    public class CartController : Controller
    {
        private readonly ICharityRepo charityRepo;
        private readonly IUserRepo userRepo;

        public CartController(ICharityRepo charityRepo, IUserRepo userRepo)
        {
            this.charityRepo = charityRepo;
            this.userRepo = userRepo;
        }

        public IActionResult ViewCart()
        {
            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");

            if (cart != null)
            {
                ViewBag.Cart = cart;
                ViewBag.total = cart.Sum(c => c.Charity.Donated);
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(float donated, long charityId)
        {
            CharityItem charityItem = new CharityItem();
            var charity = await charityRepo.GetCharityById(charityId.ToString());
            List<ShoppingCart> cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");

            if (cart == null)
            {
                List<ShoppingCart> newCart = new List<ShoppingCart>();
                AddingToCart(donated, charityItem, charity, newCart);
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", newCart);

            }
            else
            {
                if (IsExist(charityId, cart))
                {
                    int index = cart.FindIndex(i => i.Charity.Charity.CharityId == charityId);

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
            List<ShoppingCart> cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");
            int index = cart.FindIndex(i => i.Charity.Charity.CharityId == charityId);

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewCart(User obj)
        {
            if (ModelState.IsValid)
            {
                userRepo.AddUser(obj);
                return RedirectToAction("Complete");
            }

            var cart = SessionHelper.GetObjectFromJson<List<ShoppingCart>>(HttpContext.Session, "cart");

            ViewBag.Cart = cart;
            ViewBag.total = cart.Sum(c => c.Charity.Donated);

            return View(obj);
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
