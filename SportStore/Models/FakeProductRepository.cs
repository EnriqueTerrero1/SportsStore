namespace SportStore.Models
{
    public class FakeProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product {Name= "Football",Price = 25},
            new Product {Name ="Surf Board",Price =179},
            new Product {Name ="Running Shoes",Price=95}
        };
    }
}
