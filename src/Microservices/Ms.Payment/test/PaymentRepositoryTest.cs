using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

public class PaymentRepositoryTest
{
    [Fact]
    public async void should_to_create_payment()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase(databaseName:"teste").Options;

        var appDbContextMock = new Mock<AppDbContext>(options);

        var paymentModel = new PaymentModel(new DateTime(), 1);

        var entityEntry = appDbContextMock.Object.Entry(new PaymentModel(new DateTime(), 1));

        appDbContextMock.Setup(db => db.payments.AddAsync(It.IsAny<PaymentModel>(), CancellationToken.None)).ReturnsAsync(entityEntry);

        var paymentRepository = new PaymentRepository(appDbContextMock.Object);

        var result = await paymentRepository.create(paymentModel);

        Assert.Equal(paymentModel, result);
    }
}