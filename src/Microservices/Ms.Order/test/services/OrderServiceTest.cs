using Moq;
using Xunit;

public class OrderServiceTest
{
    [Fact]
    public async void should_to_create_order()
    {
      var orderRepositoryMock = new Mock<IOrderRepository>();
      var conversorToModelMock = new Mock<IConversorDtoToModel>();
      var rabbitMqMock = new Mock<IRabbitMq>();
      var orderDto = new OrderDto();
      var orderModel = new OrderModel(new DateTime(), 1200);
      conversorToModelMock.Setup(c => c.conversor(orderDto)).Returns(orderModel);
      orderRepositoryMock.Setup(o => o.create(orderModel)).ReturnsAsync(orderModel);
      var orderService = new OrderService(orderRepositoryMock.Object, conversorToModelMock.Object, rabbitMqMock.Object);
      var result = await orderService.create(orderDto);
      Assert.Equal(result.totalOrderValue, orderModel.totalOrderValue);
      Assert.Equal(result.date, orderModel.date);
    }
}