

namespace SportStore.Models
{
    public class CartIndexViewModel
    {


        public IEnumerable<CartLine> Carts { get; set; }

        public decimal Total;
        
    }
}
