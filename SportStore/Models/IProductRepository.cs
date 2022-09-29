using System.Collections.Generic;

namespace SportStore.Models
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }

    }
}
