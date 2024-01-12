
public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _context;

    public OrderRepository(AppDbContext context){
        _context = context;
    }
    public async Task<OrderModel> create(OrderModel orderModel)
    {
       var newOrder = await _context.orders.AddAsync(orderModel);
       await _context.SaveChangesAsync();
       return orderModel;
       
    }
}