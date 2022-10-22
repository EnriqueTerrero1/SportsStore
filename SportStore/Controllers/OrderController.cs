using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using Microsoft.AspNetCore.Authorization;
namespace SportStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly ICartRepository cartRepository;

        public OrderController(IOrderRepository orderRepository, ICartRepository cartRepository)
        {
            this.orderRepository = orderRepository;
            this.cartRepository = cartRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Checkout() => View(new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cartRepository.Lines.Count() == 0)
            {
                ModelState.AddModelError(" ", "Sorry, your cart is empty!");
            }

            order.Lines = cartRepository.Lines.ToArray();
            order.Shipped = false;
            if (!ModelState.IsValid)
            {
                orderRepository.SaveOrder(order);
                return RedirectToAction(nameof(Completed));
            }
            else
            {
                return View(order);
            }
        }
        public ViewResult Completed()
        {
            cartRepository.Clear();
            return View();
        }
        [Authorize]
        public ViewResult List() => View(orderRepository.Orders.Where(o => !o.Shipped));

        [HttpPost]
        [Authorize]

        public IActionResult MarkShipped(int orderID)
        {
            Order order = orderRepository.Orders.FirstOrDefault(o => o.OrderId == orderID);

            if (order != null)
            {
                order.Shipped = true;
                orderRepository.SaveOrder(order);
            }
            return RedirectToAction(nameof(List));
        }

    }
}
