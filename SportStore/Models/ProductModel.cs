namespace SportStore.Models
{
    public class ProductModel
    {
       public IEnumerable<Product> Products { get; set; }
      
        public double PageCount { get; set; }
    }
}
