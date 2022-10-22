namespace SportStore.Models
{
    public class ProductRepository:IProductRepository
    {
        private ApplicationDbContext context;
        private readonly string connectionString;
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
        public int maxRow = 2;
        


        public ProductRepository (ApplicationDbContext ctx, IConfiguration configuration)
        {
            context = ctx;
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

       
        public IEnumerable<Product> Products => context.products;

        public IEnumerable<Product> GetSortedProduct(int currentPage, string category)

        {
            var products = context.products;
            var  PagedProduct= products.Where(products => category== null || products.Category == category).OrderBy(products => products.ProductId).Skip((currentPage-1)*maxRow).Take(maxRow).ToList();
           
            getPageCount(category);
            CurrentPageIndex = currentPage;


            return PagedProduct;
        }
        public double getPageCount( string category)
        {
            var products = context.products;
            var amountOfProductByCategory = products.Where(products => category == null || products.Category == category).OrderBy(products => products.ProductId).ToList();

            return (double)((decimal)amountOfProductByCategory.Count() / Convert.ToDecimal(maxRow));
        }

       public void SaveProduct(Product product)
        {
            if(product.ProductId == 0)
            {
                context.products.Add(product);
            }
            else
            {
                Product dbEntry= context.products.FirstOrDefault(p => p.ProductId == product.ProductId);

                if(dbEntry != null)
                {
                    dbEntry.Name = product.Name;
                    dbEntry.Description = product.Description;
                    dbEntry.Category = product.Category;
                    dbEntry.Price = product.Price;
                }
                
            }
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.products.Remove(product);
            context.SaveChanges();
        }


    }
}
