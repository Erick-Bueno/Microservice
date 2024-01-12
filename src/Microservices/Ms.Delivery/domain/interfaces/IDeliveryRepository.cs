public interface IDeliveryRepository
{
    public Task<DeliveryModel> CreateDelivery(DeliveryModel deliveryModel);
}