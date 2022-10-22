namespace SportStore.Models
{
    public class OrderViewModel
    {

        public Order Order { get; set; }

        public IEnumerable<CartRepository> Lines { get; set; }
    }
}
