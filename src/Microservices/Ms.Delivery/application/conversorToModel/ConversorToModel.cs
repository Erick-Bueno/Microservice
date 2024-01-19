public class ConversorToModel:IConversorToModel
{
    public DeliveryModel conversor(int id){
        DeliveryModel  deliveryModel = new DeliveryModel(id, DeliveryStatus.PENDING);
        return deliveryModel;
    }
}