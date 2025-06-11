using Domain.Entities;
using Domain.Enums;  // Import your Roles class here
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    [Authorize(Roles = Roles.Admin + "," + Roles.Moderator + "," + Roles.BasicUser)]
    public IActionResult GetAll()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }

    [HttpPost]
    [Authorize(Roles = Roles.Admin)]
    public IActionResult Add(Product product)
    {
        var added = _productService.Add(product);
        return Ok(added);
    }

    [HttpPut("{id}")]
    [Authorize(Roles = Roles.Admin)]
    public IActionResult Update(int id, Product product)
    {
        var updated = _productService.Update(id, product);
        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.Admin)]
    public IActionResult Delete(int id)
    {
        var deleted = _productService.Delete(id);
        return deleted ? Ok() : NotFound();
    }
}
