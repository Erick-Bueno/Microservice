using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class OrderRepositoryTest
{
    [Fact]
    public async void should_to_create_order()
    {
      var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName:"Teste").Options;

      var appDbContextMock = new Mock<AppDbContext>(options);

      OrderModel orderModel = new OrderModel(new DateTime(),1050);

      var entityEntry = appDbContextMock.Object.Entry(new OrderModel(new DateTime(),1050));

      appDbContextMock.Setup(db => db.orders.AddAsync(It.IsAny<OrderModel>(),CancellationToken.None)).ReturnsAsync(entityEntry);

      var orderRepository = new OrderRepository(appDbContextMock.Object);

      var result = await orderRepository.create(orderModel);

      Assert.Equal(orderModel, result);
    }
}