using Microsoft.AspNetCore.Mvc;
using Testing.Models;


namespace DemoApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private static List<Product> products = new List<Product>
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99M },
        new Product { Id = 2, Name = "Phone", Price = 499.99M },
        new Product { Id = 3, Name = "Tablet", Price = 299.99M }
    };

    // GET: api/product
    [HttpGet]
    public ActionResult<IEnumerable<Product>> Get()
    {
        return Ok(products);
    }

    // GET: api/product/{id}
    [HttpGet("{id}")]
    public ActionResult<Product> Get(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        return Ok(product);
    }

    // POST: api/product
    [HttpPost]
    public ActionResult<Product> Post([FromBody] Product product)
    {
        product.Id = products.Count + 1;
        products.Add(product);
        return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
    }

    // PUT: api/product/{id}
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] Product updatedProduct)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        product.Name = updatedProduct.Name;
        product.Price = updatedProduct.Price;
        return NoContent();
    }

    // DELETE: api/product/{id}
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var product = products.FirstOrDefault(p => p.Id == id);
        if (product == null)
            return NotFound();

        products.Remove(product);
        return NoContent();
    }
}

