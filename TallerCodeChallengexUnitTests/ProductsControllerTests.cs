using Microsoft.AspNetCore.Mvc;
using TallerCodeChallengeAPI.Controllers;
using TallerCodeChallengeAPI.Models;

namespace TallerCodeChallengexUnitTests;

public class ProductsControllerTests
{
    private readonly ProductController _controller;

    public ProductsControllerTests()
    {
        _controller = new ProductController();
    }

    [Fact]
    public void GetById_ReturnsNotFound_WhenProductDoesNotExist()
    {
        var result = _controller.GetPrductById(999);
        Assert.IsType<NotFoundResult>(result.Result);
    }

    [Fact]
    public void Create_AssignsUniqueId_ToNewProducts()
    {
        var product1 = new Product(1, "Test 1", (decimal)20.4);
        var product2 = new Product(2, "Test 2", (decimal)30.6);

        var result1 = _controller.AddProduct(product1);
        var result2 = _controller.AddProduct(product2);


        Assert.NotEqual(result1, result2);
    }

    [Theory]
    [InlineData(0,"", 10.0)]  // Empty name
    [InlineData(0, "Test", -1)]  // Negative price
    [InlineData(0, null, 10.7)]  // Null name
    public void Create_ValidatesInput(int id, string name, decimal price)
    {
        var product = new Product (id, name, price);
        var result = _controller.AddProduct(product);
        Assert.IsType<BadRequestResult>(result.Result);
    }

    [Fact]
    public void Update_ReturnsNotFound_WhenProductDoesNotExist()
    {
        var result = _controller.ModifyProduct(new Product(1, "Test Name", (decimal)20.5), 999);
        Assert.IsType<NotFoundResult>(result);
    }

    [Fact]
    public void Delete_RemovesProduct_WhenProductExists()
    {
        // Arrange
        var product = new Product(56, "Test Name", (decimal)20.5);
        var createResult = _controller.AddProduct(product);
        var id = createResult.Value;

        // Act
        var deleteResult = _controller.DeleteProduct(id);
        var getResult = _controller.GetPrductById(id);

        // Assert
        Assert.IsType<NotFoundResult>(getResult.Result);
    }
}
