using Microsoft.AspNetCore.Mvc;
using SportStore.Models;

using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportStore.Controllers
{
    public class ProductController : Controller

    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository repo )
        {
            repository = repo;
           

        }


        
        [HttpGet]
       public IActionResult List(int currentPageIndex)
        {
            if(currentPageIndex < 1)
            {
                currentPageIndex = 1;
            }
            ProductModel productModel = new ProductModel();
            productModel.Products = repository.GetEFProduct(currentPageIndex);

            productModel.PageCount = repository.getPageCount();


            return View(productModel);
        }
    
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
