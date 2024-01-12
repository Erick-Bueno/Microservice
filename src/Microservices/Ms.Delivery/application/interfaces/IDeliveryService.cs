public interface IDeliveryService
{
    public Task<DeliveryModel> CreateDelivery(DeliveryDto deliveryDto);
}