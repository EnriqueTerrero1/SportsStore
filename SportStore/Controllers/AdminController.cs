using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
namespace SportStore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IProductRepository productRepository;

        public AdminController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IActionResult Index()
        {
            
            return View(productRepository.Products);
        }
        public IActionResult Edit(int ProductId)
        {
            ViewBag.title = "Edit Product";
            var product = productRepository.Products.FirstOrDefault(id => id.ProductId == ProductId);
            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                productRepository.SaveProduct(product);
                TempData["message"] = $"{product.Name} has been saved";
                return RedirectToAction("Index");

            }
            else
            {
                return View(product);
            }
        }
        [HttpPost]
        public IActionResult Delete(int productId)
        {
            var product = productRepository.Products.FirstOrDefault(id => id.ProductId == productId);
            productRepository.DeleteProduct(product);
            return RedirectToAction("Index");
        }

        public ViewResult Create()
        {
            ViewBag.title = "Create Product";

            return View("Edit", new Product());
        }

    }
}
