using BackendFirstStage.Applications.DTOs;
using BackendFirstStage.Applications.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackendFirstStage.Api.Controllers;

/// <summary>
/// Controller for managing products.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductController"/> class.
    /// </summary>
    /// <param name="productService">Service for product operations.</param>
    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    /// <summary>
    /// Adds a new product.
    /// </summary>
    /// <param name="createProductDto">Product data to create.</param>
    /// <returns>Details of the created product.</returns>
    [HttpPost]
    public async Task<ActionResult<ProductDetailDto>> CreateProduct([FromBody] CreateProductDto createProductDto)
    {
        try
        {
            // Create a new product using the service
            var newProduct = await _productService.CreateProductAsync(createProductDto);
            // Return 201 Created with the new product details
            return CreatedAtAction(nameof(GetProductById), new { id = newProduct.Id }, newProduct);
            // Alternative response format:
            // return Ok(new { Status = true, Message = "Ürün başarıyla eklendi", Data = newProduct});
        }
        catch (Exception ex)
        {
            // Return 400 Bad Request with error message
            return BadRequest(new { message = ex.Message });
        }
    }

    /// <summary>
    /// Lists all products.
    /// </summary>
    /// <returns>List of products.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProductListDto>>> GetAllProducts()
    {
        try
        {
            // Retrieve all products using the service
            var products = await _productService.GetAllProductsAsync();
            // Return 200 OK with product list
            return Ok(new { Status = true, Message = "Listeleme işlemi başarılı", Data = products });
        }
        catch (Exception ex)
        {
            // Return 400 Bad Request with error message
            return BadRequest(new { Status = false, Message = ex.Message });
        }
    }

    /// <summary>
    /// Gets product details by ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <returns>Product details.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailDto>> GetProductById(int id)
    {
        try
        {
            // Retrieve product by ID using the service
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                // Return 404 Not Found if product does not exist
                return NotFound(new { Status = false, Message = "Ürün bulunamadı" });
            }
            // Return 200 OK with product details
            return Ok(product);
        }
        catch (Exception ex)
        {
            // Return 400 Bad Request with error message
            return BadRequest(new { Status = false, Message = ex.Message });
        }
    }

    /// <summary>
    /// Deletes a product by ID.
    /// </summary>
    /// <param name="id">Product ID.</param>
    /// <returns>Status of the delete operation.</returns>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProduct(int id)
    {
        try
        {
            // Delete product by ID using the service
            var result = await _productService.DeleteProductAsync(id);
            if (!result)
            {
                // Return 404 Not Found if product does not exist or cannot be deleted
                return NotFound(new { Status = false, Message = "Ürün bulunamadı veya silinemedi" });
            }
            // Return 200 OK if product is deleted successfully
            return Ok(new { Status = true, Message = "Ürün başarıyla silindi" });
        }
        catch (Exception ex)
        {
            // Return 400 Bad Request with error message
            return BadRequest(new { Status = false, Message = ex.Message });
        }
    }
}
