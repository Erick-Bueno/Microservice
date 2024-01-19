using Moq;
using Xunit;

public class PaymentServiceTest
{
    [Fact]
    public async void should_to_create_payment()
    {
      var paymentRepositoryMock = new Mock<IPaymentRepository>();
      var conversorToModelMock = new Mock<IConversorToModel>();
      var rabbitMqMock = new Mock<IRabbitMq>();
      var date = new DateTime();
      var data = $"1, {date}";
      PaymentModel paymentModel = new PaymentModel(date, 1);
      conversorToModelMock.Setup(c => c.conversor(date, 1)).Returns(paymentModel);
      paymentRepositoryMock.Setup(o => o.create(paymentModel)).ReturnsAsync(paymentModel);
      var paymentService = new PaymentService(paymentRepositoryMock.Object, conversorToModelMock.Object, rabbitMqMock.Object);
      var result = await paymentService.create(data);
      Assert.Equal(result.date, paymentModel.date);
      Assert.Equal(result.idOrder, paymentModel.idOrder);
    }
}