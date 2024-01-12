public class ConversorDtoToModel:IConversorDtoToModel
{
    public DeliveryModel conversor(DeliveryDto deliveryDto){
        DeliveryModel  deliveryModel = new DeliveryModel(deliveryDto.orderId, deliveryDto.status);
        return deliveryModel;
    }
}