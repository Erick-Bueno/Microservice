public class ConversorDtoToModel : IConversorDtoToModel
{
    public OrderModel conversor(OrderDto orderDto)
    {
        OrderModel orderModel = new OrderModel(orderDto.date, orderDto.totalOrderValue);
        return orderModel;
    }
}