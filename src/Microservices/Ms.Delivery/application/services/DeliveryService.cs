
public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IConversorToModel _conversorToModel;
    public DeliveryService(IDeliveryRepository deliveryRepository, IConversorToModel conversorDtoToModel){
        _deliveryRepository = deliveryRepository;
        _conversorToModel = conversorDtoToModel;
    }
    public async Task<DeliveryModel> createDelivery(string data)
    {
       int id = int.Parse(data);
       var deliveryModel = _conversorToModel.conversor(id);
       var newDelivery = await _deliveryRepository.CreateDelivery(deliveryModel);
       return newDelivery;
    }
}