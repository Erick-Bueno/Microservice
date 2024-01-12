using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore.ChangeTracking;

public class DeliveryRepositoryTest
{
    [Fact]
    public async void should_to_create_delivery()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName:"teste").Options;
        var appDbContextMock = new Mock<AppDbContext>(options);
   
        var entityEntry = appDbContextMock.Object.Entry(new DeliveryModel(1,DeliveryStatus.PENDING));

        DeliveryModel deliveryModel = new DeliveryModel(1, DeliveryStatus.PENDING);
        appDbContextMock.Setup(db => db.Deliveries.AddAsync(It.IsAny<DeliveryModel>(),CancellationToken.None)).ReturnsAsync(entityEntry);


        var DeliveryRepository = new DeliveryRepository(appDbContextMock.Object);
        var result = await DeliveryRepository.CreateDelivery(deliveryModel);

        Assert.Equal(deliveryModel , result);
        Assert.Equal(deliveryModel.status, result.status);
        Assert.Equal(deliveryModel.idOrder, result.idOrder);
    }
}