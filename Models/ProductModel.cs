namespace LR6.Services
{
    public class ProductModel
    {
        public int id { get; set; }

        public string Type { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }

        public List<ProductModel> GetProducts()
        {
            return ProductModel.products;
        }

        private static List<ProductModel> products = new List<ProductModel>();

        static ProductModel()
        {
            products = new List<ProductModel>
        {
            // Піци
            new ProductModel { id = 1, Type = "Pizzas", Name = "Four cheese", Price = 11.49, AvailableQuantity = 25 },
            new ProductModel { id = 2, Type = "Pizzas", Name = "Buffalo chicken", Price = 12.99, AvailableQuantity = 14 },
            new ProductModel { id = 3, Type = "Pizzas", Name = "Pesto veggie", Price = 10.49, AvailableQuantity = 16 },
            new ProductModel { id = 4, Type = "Pizzas", Name = "Margherita", Price = 8.99, AvailableQuantity = 20 },
            new ProductModel { id = 5, Type = "Pizzas", Name = "Pepperoni", Price = 10.99, AvailableQuantity = 15 },
            new ProductModel { id = 6, Type = "Pizzas", Name = "Hawaiian", Price = 11.99, AvailableQuantity = 12 },
            new ProductModel { id = 7, Type = "Pizzas", Name = "Veggie supreme", Price = 9.49, AvailableQuantity = 18 },

            // Напої
            new ProductModel { id = 8, Type = "Beverages", Name = "Coca-Cola", Price = 1.99, AvailableQuantity = 50 },
            new ProductModel { id = 9, Type = "Beverages", Name = "Fanta", Price = 1.99, AvailableQuantity = 35 },
            new ProductModel { id = 10, Type = "Beverages", Name = "Mineral water", Price = 1.49, AvailableQuantity = 60 },
            new ProductModel { id = 11, Type = "Beverages", Name = "Orange juice", Price = 2.49, AvailableQuantity = 30 },
            new ProductModel { id = 12, Type = "Beverages", Name = "Iced tea", Price = 2.19, AvailableQuantity = 40 },
            new ProductModel { id = 13, Type = "Beverages", Name = "Lemonade", Price = 2.19, AvailableQuantity = 35 },

            // Страви
            new ProductModel { id = 14, Type = "Appetisers", Name = "Garlic bread", Price = 4.99, AvailableQuantity = 25 },
            new ProductModel { id = 15, Type = "Appetisers", Name = "Chicken wings", Price = 7.99, AvailableQuantity = 15 },
            new ProductModel { id = 16, Type = "Appetisers", Name = "Caesar salad", Price = 6.49, AvailableQuantity = 20 },
            new ProductModel { id = 17, Type = "Appetisers", Name = "Mozzarella sticks", Price = 5.99, AvailableQuantity = 18 },
            new ProductModel { id = 18, Type = "Appetisers", Name = "Pasta carbonara", Price = 10.99, AvailableQuantity = 12 },
            new ProductModel { id = 19, Type = "Appetisers", Name = "Stuffed mushrooms", Price = 7.49, AvailableQuantity = 14 },
            new ProductModel { id = 20, Type = "Appetisers", Name = "Bruschetta", Price = 5.49, AvailableQuantity = 30 },
            };
        }
    }
}
