using Microsoft.EntityFrameworkCore;

namespace SportStore.Models
{
    public class EFOrderRepository : IOrderRepository
    {

        private ApplicationDbContext context;

        public EFOrderRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Order> Orders => context.orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);


        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Lines.Select(l => l.Product));


            if (order.OrderId == 0)
            {
                context.orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}