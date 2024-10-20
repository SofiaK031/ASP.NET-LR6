namespace LR6.Services
{
    public interface IOrderService
    {
        OrderModel CreateOrder(Guid customerGuid);

        OrderModel GetOrder(Guid orderId);

        bool AddProduct(OrderModel order, ProductModel product, int quantity);
    }
}
