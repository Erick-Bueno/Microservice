public class ConversorToModel : IConversorToModel
{
    public PaymentModel conversor(DateTime date, int id)
    {
        PaymentModel paymentModel = new PaymentModel(date, id);
        return paymentModel;
    }
}