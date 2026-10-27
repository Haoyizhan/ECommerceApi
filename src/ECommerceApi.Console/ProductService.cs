using System;
using System.Collections.Generic;
using System.Linq;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    // 新增商品
    public void AddProduct(Product product)
    {
        product.Id = _nextId;
        _nextId++;

        _products.Add(product);
    }

    // 查詢單筆商品
    public Product? GetProduct(int id)
    {
        return _products.FirstOrDefault(p => p.Id == id);
    }

    // 查詢所有商品
    public List<Product> GetProducts()
    {
        return _products.ToList();
    }

    // 修改商品
    public bool UpdateProduct(Product product)
    {
        var existingProduct = GetProduct(product.Id);

        if (existingProduct == null)
        {
            return false;
        }

        existingProduct.Name = product.Name;
        existingProduct.Price = product.Price;
        existingProduct.Stock = product.Stock;

        return true;
    }

    // 刪除商品
    public bool DeleteProduct(int id)
    {
        var product = GetProduct(id);

        if (product == null)
        {
            return false;
        }

        return _products.Remove(product);
    }

    // 搜尋商品
    public List<Product> SearchProduct(string keyword)
    {
        return _products
            .Where(p => p.Name.Contains(
                keyword,
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}