using System.Collections.Generic;
using ECommerceApi.Console.Models;

namespace ECommerceApi.Console.Interfaces;

public interface IProductService
{
    void AddProduct(Product product);

    Product? GetProduct(int id);

    List<Product> GetProducts();

    bool UpdateProduct(Product product);

    bool DeleteProduct(int id);

    List<Product> SearchProduct(string keyword);
}