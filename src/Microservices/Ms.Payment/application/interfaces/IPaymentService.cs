public interface IPaymentService
{
    public Task<PaymentModel> create(PaymentDto paymentDto);
}