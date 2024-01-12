
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IConversorDtoToModel _conversorDtoToModel;
    public OrderService(IOrderRepository orderRepository, IConversorDtoToModel conversorDtoToModel){
        _orderRepository = orderRepository;
        _conversorDtoToModel = conversorDtoToModel;
    }
    public async Task<OrderModel> create(OrderDto orderDto)
    {
        OrderModel orderModel = _conversorDtoToModel.conversor(orderDto);
        OrderModel newOrder = await _orderRepository.create(orderModel);
        //enviar mensagem para fila contendo id do pedido e o valor total do pedido
        return newOrder;
        
    }
}