
public class PaymentRepository : IPaymentRepository
{
    private readonly AppDbContext _context;
    public PaymentRepository(AppDbContext context){
        _context = context;
    }
    public async Task<PaymentModel> create(PaymentModel paymentModel)
    {
        var newPayment = await _context.AddAsync(paymentModel);
        await _context.SaveChangesAsync();
        return paymentModel;
    }
}