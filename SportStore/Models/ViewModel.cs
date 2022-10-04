namespace SportStore.Models
{
    public class ViewModel
    {
       public IEnumerable<Product> Products { get; }
        int currentPage = 1;
        int currentPageIndex = 2;
    }
}
