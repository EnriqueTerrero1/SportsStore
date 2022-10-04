using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportStore.Controllers
{
    public class ProductController : Controller

    {
        private readonly IProductRepository repository;
        public ProductController(IProductRepository repo)
        {
            repository = repo;

        }

        public  IActionResult List()

        
        {
            
           return View(repository.GetEFProduct(1));
        }

        [HttpPost]
       public IActionResult List(int currentPageIndex)
        {

            return View(repository.GetEFProduct(currentPageIndex));
        }
    
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
