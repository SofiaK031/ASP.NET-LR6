namespace LR6.Services
{
    public interface IProductService
    {
        List<ProductModel> GetProducts();

        ProductModel FindProductById(int id);
    }
}
