
public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository _deliveryRepository;
    private readonly IConversorDtoToModel _conversorDtoToModel;
    public DeliveryService(IDeliveryRepository deliveryRepository, IConversorDtoToModel conversorDtoToModel){
        _deliveryRepository = deliveryRepository;
        _conversorDtoToModel = conversorDtoToModel;
    }
    public async Task<DeliveryModel> CreateDelivery(DeliveryDto deliveryDto)
    {
       throw new NotImplementedException();
       var deliveryModel = _conversorDtoToModel.conversor(deliveryDto);
       var newDelivery = await _deliveryRepository.CreateDelivery(deliveryModel);
    }
}