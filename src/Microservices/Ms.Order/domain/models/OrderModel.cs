using System.ComponentModel.DataAnnotations.Schema;

public class OrderModel
{
    public int id { get; private set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid externalId { get; private set; }
    public DateTime date { get; set; }
    public Decimal totalOrderValue { get; set; }

    public OrderModel(DateTime date, Decimal totalOrderValue){
        this.date = date;
        this.totalOrderValue = totalOrderValue;
    }

}