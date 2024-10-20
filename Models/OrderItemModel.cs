using LR6.Models;

namespace LR6.Services
{
    public class OrderItemModel
    {
        public Guid Id { get; set; }
        public ProductModel Product { get; set; }
        public int Quantity { get; set; }
    }
}
