namespace SportStore.Models
{
    public interface ICart
    {


       // public List<CartLine> lineCollection { get; }


        public void AddItem(Product product, int quantity);


        public  void RemoveLine(Product product);

        public void EditFromCart(CartLine cartLine);



        public decimal ComputeTotalValue();

        public  void Clear();

        public  IEnumerable<CartLine> Lines { get; }

    }

}
