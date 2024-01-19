
using Xunit;

public class ConversorToModelTest
{
    [Fact]
    public void should_to_convert_data_in_payment_model()
    {
        ConversorToModel conversorToModel = new ConversorToModel();
        DateTime date = new DateTime();
        PaymentModel paymentModel = new PaymentModel(date, 1);
        var result = conversorToModel.conversor(date, 1);
        Assert.Equal(result.date, paymentModel.date);
        Assert.Equal(result.idOrder, paymentModel.idOrder);
    }
}