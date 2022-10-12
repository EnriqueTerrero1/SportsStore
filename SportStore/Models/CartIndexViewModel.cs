

namespace SportStore.Models
{
    public class CartIndexViewModel
    {

        //public Cart cart { get; set; }

        public IEnumerable<CartLine> Carts { get; set; }

        public decimal Total;
        
    }
}
