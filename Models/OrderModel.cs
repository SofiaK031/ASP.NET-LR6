namespace LR6.Services
{
    public class OrderModel
    {
        public Guid Id { get; set; }
        public UserModel Customer { get; set; }
        public List<OrderItemModel> Products { get; set; } = new List<OrderItemModel>();

        public OrderModel()
        {
            Id = Guid.NewGuid();
        }
    }
}
