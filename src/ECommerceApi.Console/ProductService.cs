public class ProductService
{
    private List<Product> products = new List<Product>();

    public void AddProduct(Product product)
    {
        // 新增
    }

    public Product? GetProduct(int id)
    {
        // 查詢單筆
        return products.FirstOrDefault(x => x.Id == id);
    }

    public List<Product> GetProducts()
    {
        // 查詢全部
        return products;
    }

    public void UpdateProduct(Product product)
    {
        // 修改
    }

    public void DeleteProduct(int id)
    {
        // 刪除
    }

    public List<Product> SearchProduct(string keyword)
    {
        var result = products
            .Where(x => x.Name.Contains(
                keyword,
                StringComparison.OrdinalIgnoreCase))
            .ToList();

        return result;
    }
}