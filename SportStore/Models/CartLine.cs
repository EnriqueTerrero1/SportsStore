using System.Collections.Generic;
using System.Linq;

namespace SportStore.Models
{


    public class CartLine
    {
        public Guid CartLineID { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }


    }
}