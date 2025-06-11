using Domain.Entities;

public interface IProductService
{
    List<Product> GetAll();
    Product Add(Product product);
    Product Update(int id, Product product);
    bool Delete(int id);
}
