using Xunit;

public class ConvertDtoToModelTest
{
    [Fact]
    public void should_to_convert_orderdto_to_ordermodel()
    {
       var conversorDtoToModel = new ConversorDtoToModel();
       OrderDto orderDto = new OrderDto();
       orderDto.totalOrderValue = 1200;
       DateTime date = new DateTime();
       OrderModel orderModel = new OrderModel(date, 1200);
       var result = conversorDtoToModel.conversor(orderDto);
       Assert.Equal(result.date, orderModel.date);
       Assert.Equal(result.totalOrderValue, orderModel.totalOrderValue);

    }
}