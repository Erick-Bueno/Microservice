
public class DeliveryRepository : IDeliveryRepository
{
    private readonly AppDbContext _context;

    public DeliveryRepository(AppDbContext context){
        _context = context;
    }
    public async Task<DeliveryModel> CreateDelivery(DeliveryModel deliveryModel)
    {
        var newDelivery = await _context.Deliveries.AddAsync(deliveryModel);
        await _context.SaveChangesAsync();
        return deliveryModel;
    }
}