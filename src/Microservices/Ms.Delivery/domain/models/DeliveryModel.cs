
using System.ComponentModel.DataAnnotations.Schema;

public class DeliveryModel
{
    public int id { get; private set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int idOrder { get; set; }
    public Guid externalId { get; private set; }
    public DeliveryStatus status { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public DateTime deliveryDate { get; set; }

    public DeliveryModel(int idOrder, DeliveryStatus status){
        this.idOrder = idOrder;
        this.status = status;
    }

}