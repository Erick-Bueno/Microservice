public class PaymentModel
{
    public int id { get; private set; }
    public Guid externalId { get; private set; }
    public DateTime date { get; set; }
    public int idOrder { get; set; }

    public PaymentModel(DateTime date, int idOrder){
        this.date = date;
        this.idOrder = idOrder;
    }
    
    
    
}