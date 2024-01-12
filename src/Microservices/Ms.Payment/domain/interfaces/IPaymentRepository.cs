public interface IPaymentRepository
{
    public Task<PaymentModel> create(PaymentModel paymentModel);
}