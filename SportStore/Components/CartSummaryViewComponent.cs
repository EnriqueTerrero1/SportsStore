using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Components
{

    public class CartSummaryViewComponent: ViewComponent
    {
        private ICartRepository cart;

        public CartSummaryViewComponent(ICartRepository cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
