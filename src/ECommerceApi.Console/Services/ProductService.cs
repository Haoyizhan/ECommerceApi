using System;
using System.Collections.Generic;
using System.Linq;
using ECommerceApi.Console.Interfaces;
using ECommerceApi.Console.Models;

namespace ECommerceApi.Console.Services;


public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    // 新增商品
    public void AddProduct(Product product)
    {
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        ValidateProduct(product);
        product.Id = _nextId;
        _nextId++;

        _products.Add(product);
    }

    // 查詢單筆商品
    public Product? GetProduct(int id)
    {
        if (id <= 0)
        {
            throw new ArgumentOutOfRangeException(
                nameof(id), "商品 ID 必須大於 0。");
        }
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
        if (product is null)
        {
            throw new ArgumentNullException(nameof(product));
        }

        ValidateProduct(product);
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
         if (string.IsNullOrWhiteSpace(keyword))
        {
            throw new ArgumentException(
                "搜尋關鍵字不可為空白。", nameof(keyword));
        }
        return _products
            .Where(p => p.Name.Contains(
                keyword,
                StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
     private static void ValidateProduct(Product product)
    {
        if (string.IsNullOrWhiteSpace(product.Name))
        {
            throw new ArgumentException(
                "商品名稱不可為空白。", nameof(product.Name));
        }

        if (product.Price < 0)
        {
            throw new ArgumentException(
                "商品價格不可小於 0。", nameof(product.Price));
        }

        if (product.Stock < 0)
        {
            throw new ArgumentException(
                "商品庫存不可小於 0。", nameof(product.Stock));
        }
    }
}