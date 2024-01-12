public class ConversorDtoToModel : IConversorDtoToModel
{
    public PaymentModel conversor(PaymentDto paymentDto)
    {
        PaymentModel paymentModel = new PaymentModel(paymentDto.date, paymentDto.idOrder);
        return paymentModel;
    }
}