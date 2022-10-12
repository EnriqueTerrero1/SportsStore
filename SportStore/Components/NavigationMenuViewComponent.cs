using Microsoft.AspNetCore.Mvc;
using SportStore.Models;
using System.Linq;

namespace SportStore.Components
{
    public class NavigationMenuViewComponent: ViewComponent
    {
        private IProductRepository repository;

        public NavigationMenuViewComponent(IProductRepository repo)
        {
            repository = repo;

        }
        public IViewComponentResult Invoke( string category)
        {
           
            return View(repository.Products.Select(x => x.Category).Distinct().OrderBy(x => x));
        }
        
    }
}
