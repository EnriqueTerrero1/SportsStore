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

        public IEnumerable<Product> GetEFProduct(int currentPage)

        {
           
            var products = context.products;

            var  PagedProduct= products.OrderBy(products => products.ProductId).Skip((currentPage-1)*maxRow).Take(maxRow).ToList();

            getPageCount();
            CurrentPageIndex = currentPage;

            return PagedProduct;
        }
        public double getPageCount()
        {
            var products = context.products;

            return (double)((decimal)products.Count() / Convert.ToDecimal(maxRow));
        }


    }
}
