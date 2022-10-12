using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class CartController : Controller
    {
        private readonly IProductRepository repository;
        private readonly ICart cart;

        public CartController(IProductRepository repo, ICart cart)
        {
            repository = repo;
            this.cart = cart;
        }
        public IActionResult Index()
        {
            CartIndexViewModel model = new CartIndexViewModel
            {
                Carts = cart.Lines,
                Total= cart.ComputeTotalValue()
            };
            
            return View(model);
        }


        public IActionResult AddToCart(int productId)
        {
            Product product = repository.Products.FirstOrDefault(x => x.ProductId == productId);

            if (product != null)
            {
                cart.AddItem(product, 1);


                return RedirectToAction("index",cart);
            }
            return View("no encontrado");

        }

        public IActionResult RemoveFromCart( CartLine cartLine)
        {

            
            Product product = repository.Products.FirstOrDefault(x => x.ProductId == cartLine.Product.ProductId);
            if( product != null)
            {
                cart.RemoveLine(product);
            }
            return RedirectToAction("index");
          

        }

        public IActionResult EditFromCart(CartLine cartLine)
        {
            Product product = repository.Products.FirstOrDefault(x => x.ProductId == cartLine.Product.ProductId);

            cartLine.Product = product;
            
            return View(cartLine);
        }

        [HttpPost]
        public IActionResult EditFromCart1(CartLine cartLine)
        {
           

            cart.EditFromCart(cartLine);
            CartIndexViewModel model = new CartIndexViewModel
            {
                
                Carts = cart.Lines,
                Total = cart.ComputeTotalValue()
            };


            return View("index",model);
        }
    }
}
