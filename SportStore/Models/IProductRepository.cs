
using System.Collections.Generic;

namespace SportStore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

       public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }

        public IEnumerable<Product> GetEFProduct(int currentPage);

    }
}
