
public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IConversorDtoToModel _conversorDtoToModel;
    private readonly IRabbitMq _rabbitMq; 
    public OrderService(IOrderRepository orderRepository, IConversorDtoToModel conversorDtoToModel, IRabbitMq rabbitMq){
        _orderRepository = orderRepository;
        _conversorDtoToModel = conversorDtoToModel;
        _rabbitMq = rabbitMq;
    }
    public async Task<OrderModel> create(OrderDto orderDto)
    {
        
        OrderModel orderModel = _conversorDtoToModel.conversor(orderDto);
        OrderModel newOrder = await _orderRepository.create(orderModel);
        //enviar mensagem para fila contendo id e a data
        _rabbitMq.producer(orderModel.id, orderModel.date);
        return newOrder;
        
    }
}