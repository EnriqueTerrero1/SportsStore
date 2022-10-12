namespace SportStore.Models
{
    public class EFProductRepository:IProductRepository
    {
        private ApplicationDbContext context;
        private readonly string connectionString;
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
        public int maxRow = 2;


        public EFProductRepository (ApplicationDbContext ctx, IConfiguration configuration)
        {
            context = ctx;
            connectionString = configuration.GetConnectionString("DefaultConnection");

        }

       

        public IEnumerable<Product> Products => context.products;

        public IEnumerable<Product> GetEFProduct(int currentPage, string category)

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


    }
}
