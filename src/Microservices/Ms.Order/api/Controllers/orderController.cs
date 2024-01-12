namespace Name.Controllers
{

    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class Order : ControllerBase
    {
        private readonly IOrderService _orderService;
        public Order(IOrderService orderService){
            _orderService = orderService;
        }
        [HttpGet]
        public async Task<ActionResult<OrderModel>> CreateOrder([FromBody] OrderDto orderDto)
        {
            var newOrder = await _orderService.create(orderDto);
            return Ok("pedido feito com sucesso");
        }
    }
}