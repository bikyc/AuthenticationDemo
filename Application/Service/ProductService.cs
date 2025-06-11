using Domain.Entities;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    private int _counter = 1;

    public List<Product> GetAll() => _products;

    public Product Add(Product product)
    {
        product.Id = _counter++;
        _products.Add(product);
        return product;
    }

    public Product Update(int id, Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == id);
        if (existing == null)
            return null;

        existing.Name = product.Name;
        existing.Price = product.Price;
        return existing;
    }

    public bool Delete(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return false;
        _products.Remove(product);
        return true;
    }
}
