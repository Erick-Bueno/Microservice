
public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IConversorDtoToModel _conversorDtoToModel;
    public PaymentService(IPaymentRepository paymentRepository, IConversorDtoToModel conversorDtoToModel)
    {
        _paymentRepository = paymentRepository;
        _conversorDtoToModel = conversorDtoToModel;
    }
    public async Task<PaymentModel> create(PaymentDto paymentDto)
    {
        //ouvindo o rabbit para receber a msg e so apos isso criar o payment
        PaymentModel paymentModel = _conversorDtoToModel.conversor(paymentDto);
        var newPayment = await _paymentRepository.create(paymentModel);
        return newPayment;
    }
}