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
       public IActionResult List(int currentPageIndex,string category)
        {
            ViewBag.SelectedCategory = category;
            if (currentPageIndex < 1)
            {
                currentPageIndex = 1;
            }
            ProductModel productModel = new ProductModel();
            productModel.PageCount = repository.getPageCount(category);
            if (productModel.PageCount <1 || productModel.PageCount < currentPageIndex)
            {
                currentPageIndex = 1;
            }
            productModel.Products = repository.GetEFProduct(currentPageIndex ,category);
            productModel.CurrentCategory = category;
           

            return View(productModel);
        }
    
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
