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