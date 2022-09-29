using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class ProductController : Controller

    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repo)
        {
            repository = repo;

        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
