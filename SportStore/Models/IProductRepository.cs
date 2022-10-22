
using System.Collections.Generic;

namespace SportStore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

       public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }

        public IEnumerable<Product> GetSortedProduct(int currentPage, string category);
        public double getPageCount(string category);
       public void SaveProduct(Product product);
        public void DeleteProduct(Product product);


    }
}
