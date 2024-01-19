using Xunit;

public class ConversorToModelTest
{
    [Fact]
    public void TestName()
    {
        ConversorToModel conversorToModel = new ConversorToModel();
        DeliveryModel deliveryModel = new DeliveryModel(1, DeliveryStatus.PENDING);
        var result = conversorToModel.conversor(1);
        Assert.Equal(result.idOrder, deliveryModel.idOrder );
    }
}