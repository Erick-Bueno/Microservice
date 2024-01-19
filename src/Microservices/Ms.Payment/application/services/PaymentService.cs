
public class PaymentService : IPaymentService
{
    private readonly IPaymentRepository _paymentRepository;
    private readonly IConversorToModel _conversorToModel;
    private readonly IRabbitMq _rabbitMq;
    public PaymentService(IPaymentRepository paymentRepository, IConversorToModel conversorToModel, IRabbitMq rabbitMq)
    {
        _paymentRepository = paymentRepository;
        _conversorToModel = conversorToModel;
        _rabbitMq = rabbitMq;

    }
    public async Task<PaymentModel> create(string data)
    {
    
        var datas = data.Split(",");
        var id = int.Parse(datas[0]);
        var date = DateTime.Parse(datas[1]);
        Console.WriteLine(id);
        Console.WriteLine("ta no service");
        //ouvindo o rabbit para receber a msg e so apos isso criar o payment
        PaymentModel paymentModel = _conversorToModel.conversor(date, id);
        var newPayment = await _paymentRepository.create(paymentModel);
        _rabbitMq.producer(id);
        return newPayment;  
    }
}