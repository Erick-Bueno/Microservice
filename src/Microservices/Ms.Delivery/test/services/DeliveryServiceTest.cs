using Moq;
using Xunit;

public class DeliveryServiceTest
{
    [Fact]
    public async void should_to_create_delivery()
    {
      var deliveryRepositoryMock = new Mock<IDeliveryRepository>();
      var conversorToModelMock = new Mock<IConversorToModel>();
      var deliveryModel = new DeliveryModel(1, DeliveryStatus.PENDING);
      conversorToModelMock.Setup(c => c.conversor(1)).Returns(deliveryModel);
      deliveryRepositoryMock.Setup(d => d.CreateDelivery(deliveryModel)).ReturnsAsync(deliveryModel);
      var deliveryService = new DeliveryService(deliveryRepositoryMock.Object, conversorToModelMock.Object);
      var message = "1";
      var result = await deliveryService.createDelivery(message);
      Assert.Equal(result.idOrder, deliveryModel.idOrder);


    }
}