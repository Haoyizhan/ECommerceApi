using System;
using System.Linq;
using ECommerceApi.Console.Interfaces;
using ECommerceApi.Console.Models;
using ECommerceApi.Console.Services;

IProductService productService = new ProductService();

productService.AddProduct(new Product
{
    Name = "Apple",
    Price = 1000,
    Stock = 10
});

productService.AddProduct(new Product
{
    Name = "Keyboard",
    Price = 1500,
    Stock = 5
});

productService.AddProduct(new Product
{
    Name = "Mouse",
    Price = 800,
    Stock = 30
});

// 查詢所有商品
foreach (var product in productService.GetProducts())
{
    Console.WriteLine(
        $"{product.Id} - {product.Name} - {product.Price} - {product.Stock}");
}

// 查詢單筆商品
var foundProduct = productService.GetProduct(2);

if (foundProduct != null)
{
    Console.WriteLine($"找到商品：{foundProduct.Name}");
}

// 搜尋商品
var searchResults = productService.SearchProduct("key");

foreach (var product in searchResults)
{
    Console.WriteLine($"搜尋結果：{product.Name}");
}
// 測試 ArgumentException
try
{
    productService.AddProduct(new Product
    {
        Name = "",
        Price = -100,
        Stock = 5
    });
}
catch (ArgumentException ex)
{
    Console.WriteLine($"輸入資料錯誤：{ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"未預期的錯誤：{ex.Message}");
}
finally
{
    Console.WriteLine("新增商品測試結束。");
}

// 測試 InvalidOperationException
try
{
    var product = productService
        .GetProducts()
        .Single(p => p.Id == 999);

    Console.WriteLine(product.Name);
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"查詢操作失敗：{ex.Message}");
}