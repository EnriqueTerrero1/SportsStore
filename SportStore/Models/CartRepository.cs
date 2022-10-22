using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace SportStore.Models
{

    [Keyless]
    public class CartRepository : ICartRepository
    {




        public static List<CartLine> lineCollection = new List<CartLine>();


        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    CartLineID = new Guid(),
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }

        }

        public void RemoveLine(Product product) => lineCollection.RemoveAll(l => l.Product.ProductId == product.ProductId);


        public void EditFromCart(CartLine cartLine)
        {

            lineCollection.Find(c => c.Product.ProductId == cartLine.Product.ProductId).Quantity = cartLine.Quantity;
        }

        public decimal ComputeTotalValue() => lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public void Clear() => lineCollection.Clear();

        public IEnumerable<CartLine> Lines => lineCollection;

    }



}
